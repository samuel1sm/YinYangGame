using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GenericMechanism
{
    // Start is called before the first frame update

    private Animator animator;



    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

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
            PlayAudio();

        }

    }

    private void Update()
    {



    }

    public override bool GetStatus()
    {
        return isActivated;
    }

    public override void PlayAudio()
    {
        audioManager.PlaySound(Sound.door);
    }
}
