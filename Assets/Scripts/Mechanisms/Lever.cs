using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : GenericMechanism
{
    private Animator animator;
    [SerializeField] GenericMechanism item2BeAffected;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        animator.SetBool("isActivated", isActivated);
    }
    public override void Activate(bool canOpen)
    {
        if (!needKey)
        {
            animator.SetTrigger("activate");

            item2BeAffected.Activate(true);
            PlayAudio();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool GetStatus()
    {
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PlayAudio()
    {
        audioManager.PlaySound(Sound.button);
    }
}
