﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D playerRigidbody;

    [Header("Word Data")]
    [SerializeField] private LayerMask plataformLayerMask;
    [SerializeField] private LayerMask movebleLayerMask;

    [Header("Player Data")]
    private SpriteRenderer bodySpriteRenderer;
    private Collider2D playerMainCollider;
    private int jumpQtd ;

    [Header("Player Configs")]
    [SerializeField] private PlayerTypes playerType;
    [SerializeField] Sprite[] faces;
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private float jumpSpeed = 100;
    [SerializeField] private int maxJumpQtd = 1;
    [SerializeField] private float extraHeightText = .5f;
    [SerializeField] private float moveObjectsForce = 2f;
    [SerializeField] private float raycastAreaMaxRadius = .5f;



    #region UnityMethods
    private void Awake()
    {

        playerMainCollider = GetComponent<Collider2D>();
        bodySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        controller = new PlayerController();
        playerRigidbody = GetComponent<Rigidbody2D>();
        PlayerType = PlayerTypes.YIN;
        jumpQtd = maxJumpQtd;
    }


    private void OnEnable()
    {
        controller.Terrain.Enable();
    }

    private void OnDisable()
    {
        controller.Terrain.Disable();
    }

    void Start()
    {
        controller.Terrain.Jump.performed += _ => Jump();
        controller.Terrain.ChangeTypeYin.performed += _ => ChangePlayerType(PlayerTypes.YIN);
        controller.Terrain.ChangeTypeYang.performed += _ => ChangePlayerType(PlayerTypes.YANG);
        controller.Terrain.AttractionRepution.performed += _ => ActivateAttractRepution();
        controller.Terrain.AttractionRepution.canceled += _ => DeactivateAttractRepution();

    }

    private void FixedUpdate()
    {
        float movement = controller.Terrain.Movement.ReadValue<float>();
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnDrawGizmos()
    {
        if(playerMainCollider != null)
            Gizmos.DrawWireSphere(playerMainCollider.bounds.center, raycastAreaMaxRadius);
    }

    #endregion

    #region MyMethods

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
            //print(boxes.Length);
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

    private Vector2 Vector32Vector2(Vector3 vector)
    {
        Vector2 aux = vector;
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
            
        Debug.DrawRay(playerMainCollider.bounds.center + new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeightText),rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, playerMainCollider.bounds.extents.y + extraHeightText), Vector2.right * playerMainCollider.bounds.extents.x * 2, rayColor);

        return raycastHit.collider != null;
    }

    
    private void Jump()
    {
        if (IsGrounded())
        {
            jumpQtd = maxJumpQtd;
        }

        if (jumpQtd > 0)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * jumpSpeed);
            jumpQtd--;
        }
    }

    public void ChangePlayerType(PlayerTypes newType)
    {
        playerType = newType;
        bodySpriteRenderer.sprite = faces[(int) newType];
        gameObject.layer = (int)newType + 8;

        foreach (Transform tm in transform)
        {
            tm.gameObject.layer = (int)newType + 8;
        }
    }



    #endregion


    #region GetSetters
    public PlayerTypes PlayerType { get => playerType; set => playerType = value; }

    #endregion
}
