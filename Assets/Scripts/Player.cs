﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D playerRigidbody;

    [Header("Word Data")]
    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] private LayerMask plataformLayerMask;
    [SerializeField] private LayerMask movebleLayerMask;
    [SerializeField] private LayerMask waterLayerMask;

    [Header("Player Data")]
    private SpriteRenderer playerSpriteRenderer;
    private Collider2D playerMainCollider;
    private ResidualBody residualBody;
    private Animator auraAnimator;
    private Animator animator;
    private AudioManager audioM;
    private Vector3 testSize;
    private bool isSpirit;
    private bool isGravity;
    private bool isReturning;

    private int jumpQtd ;

    [Header("Player Configs")]
    [SerializeField] private PlayerTypes playerType;
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private float jumpSpeed = 100;
    [SerializeField] private int maxJumpQtd = 1;
    [SerializeField] private float extraHeightText = .5f;
    [SerializeField] private float moveObjectsForce = 2f;
    [SerializeField] private float raycastAreaMaxRadius = .5f;
    [SerializeField] private float returnForce = 0.5f;

    [SerializeField] private float acceptableJoinDistance = 0.5f;
    [SerializeField] private float extraDistance = 2;

    //[SerializeField] private float reaturnValue = 0.5f;



    #region UnityMethods
    private void Awake()
    {
        Time.timeScale = 1f;
        audioM = FindObjectOfType<AudioManager>();
        controller = new PlayerController();
        isReturning = false;
        auraAnimator = GetComponentsInChildren<Animator>()[1];
        residualBody = transform.GetComponentInChildren<ResidualBody>();
        isSpirit = false;
        playerMainCollider = GetComponent<Collider2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        PlayerType = PlayerTypes.YIN;
        jumpQtd = maxJumpQtd;
    }


    private void OnEnable()
    {
        controller.Terrain.Enable();
        controller.Abilities.Enable();

    }

    private void OnDisable()
    {
        controller.Terrain.Disable();
        controller.Abilities.Disable();

    }

    void Start()
    {

        controller.Terrain.Jump.performed += _ => Jump();
        controller.Abilities.ChangeTypeYang.performed += _ => ChangePlayerType(PlayerTypes.YANG);
        controller.Abilities.ChangeTypeYin.performed += _ => ChangePlayerType(PlayerTypes.YIN);
        controller.Abilities.Interact.performed += _ => InteractWithItem();
        controller.Abilities.AttractionRepution.performed += _ => ActivateAttractRepution();
        controller.Abilities.AttractionRepution.canceled += _ => DeactivateAttractRepution();
        controller.Abilities.SpiritForm.performed += _ => ChangeSpiritForm();
   

    }



    private void FixedUpdate()
    {
        if (!isReturning)
        {
            Vector3 movement;
            if (!isSpirit)
            {
                float movementValue = controller.Terrain.Movement.ReadValue<float>();
                movement = new Vector3(movementValue, 0, 0);
                if (movement != Vector3.zero && jumpQtd > 0)
                {
                    walkSound();
                    //AudioManager.PlaySound(Sound.PlayerMove);
                }

            }
            else
            {
                playerRigidbody.velocity = Vector3.zero;

                movement = controller.Air.Movement.ReadValue<Vector2>();
             

                UpdateSpiritMovement(movement);
            }

            isMovingSwitch(movement);

            transform.position += movement * Time.deltaTime * movementSpeed;
        }
  
    }

    // Update is called once per frame
    
    private void LateUpdate()
    {
        
        if(playerRigidbody.velocity.y < 0 && !isSpirit)
        {

            IsGrounded();
        }

        ActivateController(!PauseMenu.GameIsPaused || !EndLevelController.GameIsEnded);

    }



    private void OnDrawGizmos()
    {
        if(playerMainCollider != null)
        {
            Gizmos.DrawWireSphere(playerMainCollider.bounds.center, raycastAreaMaxRadius);
        }
        if(testSize != Vector3.zero)
        {
            Gizmos.DrawWireCube(playerMainCollider.bounds.center, testSize);

        }

    }



    #endregion

    #region MyMethods
    private void InteractWithItem()
    {
        testSize = playerMainCollider.bounds.size + new Vector3(playerMainCollider.bounds.extents.x + extraDistance, 0);

        RaycastHit2D raycastHit = Physics2D.BoxCast(playerMainCollider.bounds.center, playerMainCollider.bounds.size + new Vector3(playerMainCollider.bounds.extents.x + extraDistance, 0)
       , 0, Vector2.left, 0, interactablesLayerMask);

       if(raycastHit.collider != null)
        {
            raycastHit.transform.gameObject.SendMessage("Activate",false,SendMessageOptions.DontRequireReceiver);
        }
    }

    private void ChangeSpiritForm()
    {
        if (!isReturning)
        {
            isReturning = true;
            if (playerType == PlayerTypes.YANG)
            {
                Change2SpiritForm();
            }
            else
            {
                Change2GravityForm();
            }
        }

    }

    private void Change2GravityForm()
    {

        isGravity = !isGravity;
        if (isGravity)
        {
            StartCoroutine("SpiritGravitySound", false);

            ChangePlayerLayer(false);
            residualBody.ActivateAura(true);
            resetResidualBody();

            isReturning = false;
        }
        else
        {
            StartCoroutine(ResetResidualBody(false));
            StartCoroutine(ReturnPlayerMovement(false));

        }
    }

    private void Change2SpiritForm()
    {
        isSpirit = !isSpirit;
        if (isSpirit)
        {
            StartCoroutine("SpiritGravitySound", true);
            resetResidualBody();

            animator.SetTrigger("isSpirit");

            ChangePlayerLayer(false);
            controller.Terrain.Disable();
            controller.Air.Enable();
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
            isReturning = false;

        }
        else
        {
            playerMainCollider.enabled = false;

            StartCoroutine(ResetResidualBody(true));
            StartCoroutine(ReturnPlayerMovement(true));

        }
    }

    private void ActivateAttractRepution()
    {
        StartCoroutine("MovebleObjects");
        StartCoroutine("AttractionReputionSound");
        DeactivateActivateAura(true);
    }

    private void DeactivateAttractRepution()
    {
        StopCoroutine("MovebleObjects");
        StopCoroutine("AttractionReputionSound");

        DeactivateActivateAura(false);

    }

    IEnumerator MovebleObjects()
    {
        while (true)
        {
            RaycastHit2D[] boxes = Physics2D.CircleCastAll(playerMainCollider.bounds.center, raycastAreaMaxRadius, Vector3.left, 0, movebleLayerMask);

            foreach (RaycastHit2D box in boxes)
            {
                Color rayColor;
                Vector2 direction;
                if (playerType == PlayerTypes.YIN)
                {
                    direction = (Vector32Vector2(playerMainCollider.bounds.center) - box.point);
                    rayColor = Color.green;

                }
                else
                {
                    direction = (box.point - Vector32Vector2(playerMainCollider.bounds.center));
                    rayColor = Color.red;

                }

                direction.Normalize();
                Debug.DrawRay(box.collider.bounds.center, direction, rayColor);


                box.rigidbody.AddForce(direction * moveObjectsForce);


            }
            DeactivateActivateAura(true);
            yield return new WaitForEndOfFrame();

        }
        
    }


    IEnumerator ResetResidualBody(bool wasSpirit)
    {
        isReturning = true;
        while (true)
        {
            if (wasSpirit)
            {
                transform.position = Vector3.Lerp(transform.position, residualBody.GetTransform().position, returnForce * Time.deltaTime);
            }
            else
            {
                residualBody.GetTransform().position = Vector3.Lerp(residualBody.GetTransform().position, transform.position, returnForce * Time.deltaTime);
            }

            if (playerRigidbody.position == Vector32Vector2(residualBody.GetTransform().position))
            {
                break;
            }
            
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ReturnPlayerMovement(bool wasSpirit)
    {
        yield return new WaitUntil(() => Vector2.Distance(playerRigidbody.position, Vector32Vector2(residualBody.GetTransform().position)) <= acceptableJoinDistance );
        resetResidualBody();
        StopCoroutine("SpiritGravitySound");
        residualBody.GetTransform().localPosition = Vector3.zero;

        if (wasSpirit)
        {
            animator.SetTrigger("isNotSpirit");

            playerMainCollider.enabled = true;
            playerRigidbody.gravityScale = 1;
            controller.Air.Disable();
            controller.Terrain.Enable();
        }
        else
        {
            residualBody.ActivateAura(false);
        }
            ChangePlayerLayer(true);
        isReturning = false;


    }
    private Vector2 Vector32Vector2(Vector3 vector)
    {
        return vector;
    }

    private bool IsGrounded()
    {
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerMainCollider.bounds.center, playerMainCollider.bounds.size, 0f ,Vector2.down, extraHeightText, plataformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        bool result = raycastHit.collider != null;

        if (result)
        {

            jumpQtd = maxJumpQtd;
            isJumping(false);

        }
        Debug.DrawRay(playerMainCollider.bounds.center + new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeightText),rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, playerMainCollider.bounds.extents.y + extraHeightText), Vector2.right * playerMainCollider.bounds.extents.x * 2, rayColor);

        return result;
    }

    
    private void Jump()
    {
        
        if (jumpQtd > 0 && !isSpirit)
        {
            jumpQtd--;

            isJumping(true);
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * jumpSpeed);
        }

    }

    private void ActivateController(bool activate)
    {
        if (activate)
        {
            if (isSpirit)
            {
                controller.Terrain.Disable();
                controller.Air.Enable();
            }
            else
            {
                controller.Terrain.Enable();
                controller.Air.Disable();
            }
            controller.Abilities.Enable();
        }
        else
        {
            controller.Terrain.Disable();
            controller.Air.Disable();
            controller.Abilities.Disable();

        }


    }

    public void ChangePlayerType(PlayerTypes newType)
    {
        if(playerType == newType)
        {

            return;
        }

        playerType = newType;
        changeFormSound(playerType == PlayerTypes.YIN);
        SwitchColor();


        if (isSpirit)
        {
            Change2SpiritForm();
        }
        else if(isGravity)
        {
            Change2GravityForm();
        }
    }

    private void ChangePlayerLayer(bool isNormalLayer)
    {
        int newType = isNormalLayer? (int)LayersTypes.PLAYER  : (int)playerType + 8;
       
        gameObject.layer = newType;

        foreach (Transform tm in transform)
        {
            tm.gameObject.layer = newType;
        }
    }

    private void resetResidualBody()
    {
        residualBody.ResetParent();
        residualBody.ResetSpriteRenderer(playerType);

    }

    #endregion


    #region GetSetters
    public PlayerTypes PlayerType { get => playerType; set => playerType = value; }

    #endregion

    #region AnimationHandlers
    private void SwitchColor()
    {
        animator.SetBool("isYin", playerType == PlayerTypes.YIN);
        animator.SetTrigger("hasChangedColor");
    }

    private void isJumping(bool isJuping)
    {
        animator.SetBool("isJumping", isJuping);
        
    }

    private void ChangeSpiritAnimation()
    {
        if (isSpirit)
        {

            animator.SetTrigger("isSpirit");
        }
        else
        {
            animator.SetTrigger("isNotSpirit");

        }

    }

    private void UpdateSpiritMovement(Vector3 verticalMovement)
    {
        animator.SetFloat("SpiritMovement", verticalMovement.y);
        animator.SetFloat("SpiritSpeed", Mathf.Abs(verticalMovement.y));


    }

    private void isMovingSwitch(Vector3 movementValue)
    {
        if (!isSpirit)
        {
 
            animator.SetBool("isMoving", movementValue != Vector3.zero);

        }
        else
        {

        }

        if(movementValue.x != 0)
        {

            playerSpriteRenderer.flipX = movementValue.x < 0;
        }

    }

    private void DeactivateActivateAura(bool activate)
    {
        auraAnimator.SetBool("isYin", playerType == PlayerTypes.YIN);
        auraAnimator.SetBool("IsActive", activate);
    }

    #endregion

    #region AnimationHandlers

    IEnumerator SpiritGravitySound(bool isSpirit)
    {
        while (true)
        {

            float time = isSpirit ? 1.265f : 1.390f;


            audioM.PlaySound(isSpirit ? Sound.Spirit : Sound.Gravity);


            yield return new WaitForSeconds(time);


        }
    }


    IEnumerator AttractionReputionSound( )
    {
        while (true)
        {
            bool isAttraction = playerType == PlayerTypes.YIN;
            float time = isAttraction ? 0.837f :1.293f ;

          
            audioM.PlaySound(isAttraction? Sound.Attraction : Sound.Repution);
            

            yield return new WaitForSeconds(time);


        }
    }

    private void walkSound()
    {
        audioM.PlaySound(Sound.PlayerMove);

    }

    private void changeFormSound(bool isYin)
    {
        if (isYin)
        {
            audioM.PlaySound(Sound.Yin);

        }
        else
        {
            audioM.PlaySound(Sound.Yang);

        }

    }

    #endregion

}
