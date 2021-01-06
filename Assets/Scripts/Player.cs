using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D playerRigidbody;

    [Header("Word Data")]
    [SerializeField] private LayerMask plataformLayerMask;
    [SerializeField] private LayerMask movebleLayerMask;
    [SerializeField] private LayerMask waterLayerMask;

    [Header("Player Data")]
    private SpriteRenderer playerSpriteRenderer;
    private Collider2D playerMainCollider;
    [SerializeField] private int jumpQtd ;
    private bool isSpirit;
    private Transform residualBody;
    private Animator animator;
    private bool drawned;

    [Header("Player Configs")]
    [SerializeField] private PlayerTypes playerType;
    [SerializeField] Sprite[] faces;
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private float jumpSpeed = 100;
    [SerializeField] private int maxJumpQtd = 1;
    [SerializeField] private float extraHeightText = .5f;
    [SerializeField] private float moveObjectsForce = 2f;
    [SerializeField] private float raycastAreaMaxRadius = .5f;
    [SerializeField] private float returnForce = 0.5f;
    [SerializeField] private float acceptableJoinDistance = 0.5f;
    [SerializeField] private float waterVerificationDistance = 0.5f;

    //[SerializeField] private float reaturnValue = 0.5f;



    #region UnityMethods
    private void Awake()
    {
        drawned = false;
        residualBody = transform.GetChild(0);
        isSpirit = false;
        playerMainCollider = GetComponent<Collider2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = new PlayerController();
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
        controller.Abilities.ChangeTypeYin.performed += _ => ChangePlayerType(PlayerTypes.YIN);
        controller.Abilities.ChangeTypeYang.performed += _ => ChangePlayerType(PlayerTypes.YANG);
        controller.Abilities.AttractionRepution.performed += _ => ActivateAttractRepution();
        controller.Abilities.AttractionRepution.canceled += _ => DeactivateAttractRepution();
        controller.Abilities.SpiritForm.performed += _ => ChangeSpiritForm();

    }

    private void FixedUpdate()
    {
        Vector3 movement;
        if (!isSpirit)
        {
            float movementValue = controller.Terrain.Movement.ReadValue<float>();
            movement = new Vector3(movementValue, 0, 0);

        }
        else
        {
           movement = controller.Air.Movement.ReadValue<Vector2>();
           UpdateSpiritMovement(movement);
        }

        isMovingSwitch(movement);

        transform.position += movement * Time.deltaTime * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpirit)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        else
        {
        }

       //bool result =  VerifyWater(Vector2.down, waterVerificationDistance);
       // print(result);
    }

    private void LateUpdate()
    {
        
        if(playerRigidbody.velocity.y < 0 && !isSpirit)
        {

            IsGrounded();
        }

    }



    private void OnDrawGizmos()
    {
        if(playerMainCollider != null)
            Gizmos.DrawWireSphere(playerMainCollider.bounds.center, raycastAreaMaxRadius);
    }



    #endregion

    #region MyMethods
    private bool VerifyWater(Vector2 direction, float verificationDistance)
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerMainCollider.bounds.center, playerMainCollider.bounds.size, 0f, direction, verificationDistance, waterLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(playerMainCollider.bounds.center + new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + verificationDistance), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + verificationDistance), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, playerMainCollider.bounds.extents.y + verificationDistance), Vector2.right * playerMainCollider.bounds.extents.x * 2, rayColor);

        return raycastHit.collider != null;

    }

    private void ChangeSpiritForm()
    {
        if(playerType == PlayerTypes.YANG)
        {
            ChangeForm();
        }

    }


    private void ChangeForm()
    {
        isSpirit = !isSpirit;
        if (isSpirit)
        {

            ChangeSpiritAnimation();
            ChangePlayerLayer(false);
            controller.Terrain.Disable();
            controller.Air.Enable();
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
            residualBody.parent = null;

        }
        else
        {
            StartCoroutine(Move2Object());
            StartCoroutine(ReturnPlayerMovement());

        }
    }

    private void ActivateAttractRepution()
    {
        StartCoroutine("MovebleObjects");
    }

    private void DeactivateAttractRepution()
    {
        StopCoroutine("MovebleObjects");
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

            yield return new WaitForEndOfFrame();

        }
        
    }

    IEnumerator Move2Object()
    {
        playerMainCollider.enabled= false;
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, residualBody.position, returnForce * Time.deltaTime);

            if(playerRigidbody.position == Vector32Vector2(residualBody.position))
            {
                break;
            }
            
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ReturnPlayerMovement()
    {
        yield return new WaitUntil(() => Vector2.Distance(playerRigidbody.position, Vector32Vector2(residualBody.position)) <= acceptableJoinDistance );
        ChangeSpiritAnimation();

        playerMainCollider.enabled = true;
        residualBody.parent = transform;
        residualBody.transform.localPosition = Vector3.zero;
        playerRigidbody.gravityScale = 1;
        ChangePlayerLayer(true);
        controller.Air.Disable();
        controller.Terrain.Enable();
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
        if (jumpQtd > 0)
        {
            jumpQtd--;

            isJumping(true);
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * jumpSpeed);
        }
        print("asdasda " + jumpQtd);

    }

    public void ChangePlayerType(PlayerTypes newType)
    {
        playerType = newType;
        playerSpriteRenderer.sprite = faces[(int) newType];
        SwitchColor();

        if (isSpirit)
        {
            ChangeForm();
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


    #endregion


    #region GetSetters
    public PlayerTypes PlayerType { get => playerType; set => playerType = value; }

    #endregion

    #region AnimationHandlers
    private void SwitchColor()
    {
        animator.SetBool("isYin", playerType == PlayerTypes.YIN ? true : false);
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

    #endregion

}
