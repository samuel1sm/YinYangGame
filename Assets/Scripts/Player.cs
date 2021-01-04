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

    [Header("Player Data")]
    private SpriteRenderer bodySpriteRenderer;
    private Collider2D playerMainCollider;
    private int jumpQtd ;
    private bool isSpirit;
    private Transform residualBody;

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
        residualBody = transform.GetChild(0).GetChild(0);
        isSpirit = false;
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
        }
        transform.position += movement * Time.deltaTime * movementSpeed;
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
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
            controller.Terrain.Disable();
            controller.Air.Enable();
            residualBody.parent = null;

        }
        else
        {
            StartCoroutine(MoveToObject());
            //residualBody.parent = transform.GetChild(0);
            //playerRigidbody.gravityScale = 1;
            //controller.Air.Disable();
            //controller.Terrain.Enable();
        }
    }

    private void ActivateAttractRepution()
    {
        StartCoroutine(MovebleObjects());
    }

    private void DeactivateAttractRepution()
    {
        StopCoroutine(MovebleObjects());
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

    IEnumerator MoveToObject()
    {
        while (true)
        {
            playerRigidbody.MovePosition(residualBody.position);
            Vector2 aux = residualBody.position;
            yield return new WaitUntil(() =>  playerRigidbody.position == aux);
        }
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

        if (isSpirit)
        {
            ChangeForm();
        }
    }



    #endregion


    #region GetSetters
    public PlayerTypes PlayerType { get => playerType; set => playerType = value; }

    #endregion
}
