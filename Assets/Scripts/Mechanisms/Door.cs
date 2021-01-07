using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GenericMechanism
{
    // Start is called before the first frame update

    private Animator animator;
    private Collider2D doorColider;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private bool isOpen = true;
    [SerializeField] private bool needKey;
    [SerializeField] private bool isNear = false;
    [SerializeField] private float extraDistance = 0;
    [SerializeField] private bool animationEnded = true;

    private void Awake()
    {
        animationEnded = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", isOpen);
        doorColider = GetComponent<Collider2D>();
        //animator.SetBool("isOpen", isOpen);
    }

    public override void Activate()
    {
        
        animationEnded = false;
        animator.SetTrigger("OpenClose");

    }

    private void Update()
    {
        if (!needKey && animationEnded)
        {

        }


    }

    private bool CanOpenTheDoor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(doorColider.bounds.center, doorColider.bounds.size + new Vector3(doorColider.bounds.extents.x + extraDistance, 0)
            , 0, Vector2.left, 0, playerMask);


        return raycastHit.collider != null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animationEnded = true;

    }




}
