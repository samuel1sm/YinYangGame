using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GenericMechanism
{
    // Start is called before the first frame update

    private Animator animator;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isActivated", isActivated);
        //animator.SetBool("isOpen", isOpen);
    }

    public override void Activate(bool canOpen)
    {
        if (canOpen || !needKey)
        {
            isActivated = !isActivated;
            animator.SetTrigger("OpenClose");

        } 

    }

    private void Update()
    {



    }

    public override bool GetStatus()
    {
        return isActivated;
    }
}
