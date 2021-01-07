using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GenericMechanism
{
    // Start is called before the first frame update

    private Animator animator;

    [SerializeField] private bool isOpen = true;

    [SerializeField] private float extraDistance = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", isOpen);
        //animator.SetBool("isOpen", isOpen);
    }

    public override void Activate(bool canOpen)
    {
        if (canOpen || !needKey)
        {
            animator.SetTrigger("OpenClose");

        } 

    }

    private void Update()
    {



    }







}
