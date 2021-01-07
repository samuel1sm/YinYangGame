using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : GenericMechanism
{
    private Animator animator;
    [SerializeField] GenericMechanism gM;
    [SerializeField] private bool isActivated = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isActivated", isActivated);
    }
    public override void Activate(bool canOpen)
    {
        if (!needKey)
        {
            animator.SetTrigger("activate");

            gM.Activate(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
