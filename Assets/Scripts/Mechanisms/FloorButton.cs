using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : GenericMechanism
{
    [SerializeField] private int[] ableToClickInt;
    [SerializeField] private LayerMask ableToClick;
    [SerializeField] GenericMechanism item2BeAffected;
    [SerializeField] private bool isNormal;
    [SerializeField] float extraHeightText;
    private Animator buttonAnimator;
    private Collider2D collider;
    private bool previosResult;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        buttonAnimator = GetComponent<Animator>();
        buttonAnimator.SetBool("isNormal", isNormal);
    }
    private void Update()
    {
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down * -1, extraHeightText, ableToClick);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        bool result = raycastHit.collider != null;

        Activate(result != previosResult);


        previosResult = result;

        Debug.DrawRay(collider.bounds.center + new Vector3(collider.bounds.extents.x, 0), Vector2.down * -1 * (collider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(collider.bounds.center - new Vector3(collider.bounds.extents.x, 0), Vector2.down * -1 * (collider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(collider.bounds.center + new Vector3(-collider.bounds.extents.x, collider.bounds.extents.y + extraHeightText), Vector2.right * collider.bounds.extents.x * 2, rayColor);


    }

    public override void Activate(bool canOpen)
    {
        if (canOpen)
        {
            isActivated = !isActivated;
            buttonAnimator.SetBool("isActivated", isActivated);
            item2BeAffected.Activate(true);
        }
    }




    public override bool GetStatus()
    {
        return isActivated;
    }
}
