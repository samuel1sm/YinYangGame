using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : GenericMechanism
{
    [SerializeField] private bool isNormal;
    [SerializeField] private int[] ableToClickInt;
    [SerializeField] private LayerMask ableToClick;
    [SerializeField] GenericMechanism[] item2BeAffected;
    [SerializeField] float extraHeightText;
    private Animator buttonAnimator;
    private Collider2D buttonCollider;
    private bool previosResult;
    private bool previosIsHeavy;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        previosIsHeavy = false;
        buttonCollider = GetComponent<Collider2D>();
        buttonAnimator = GetComponent<Animator>();
        buttonAnimator.SetBool("isNormal", isNormal);
    }
    private void Update()
    {
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(buttonCollider.bounds.center, buttonCollider.bounds.size, 0f, Vector2.down * -1, extraHeightText, ableToClick);
        Color rayColor;

        bool isHeavy = false;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        bool result = raycastHit.collider != null;

        if (result && !isNormal)
        {

            MovebleItems mI = raycastHit.transform.gameObject.GetComponent<MovebleItems>();
            if(mI != null)
            {
                isHeavy = mI.GetIsHeavy();
            }
        }

        if (isNormal)
        {
            Activate(result != previosResult);
        }
        else
        {
            Activate(isHeavy != previosIsHeavy);
        }

     


        previosIsHeavy = isHeavy;
        previosResult = result;

        Debug.DrawRay(buttonCollider.bounds.center + new Vector3(buttonCollider.bounds.extents.x, 0), Vector2.down * -1 * (buttonCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(buttonCollider.bounds.center - new Vector3(buttonCollider.bounds.extents.x, 0), Vector2.down * -1 * (buttonCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(buttonCollider.bounds.center + new Vector3(-buttonCollider.bounds.extents.x, buttonCollider.bounds.extents.y + extraHeightText), Vector2.right * buttonCollider.bounds.extents.x * 2, rayColor);


    }

    public override void Activate(bool canOpen)
    {
        if (canOpen && item2BeAffected != null)
        {
            isActivated = !isActivated;
            buttonAnimator.SetBool("isActivated", isActivated);
            foreach (GenericMechanism gm in item2BeAffected)
            {

                gm.Activate(true);
            }
            PlayAudio();
        }
    }




    public override bool GetStatus()
    {
        return isActivated;
    }

    public override void PlayAudio()
    {
        audioManager.PlaySound(Sound.button);

    }
}
