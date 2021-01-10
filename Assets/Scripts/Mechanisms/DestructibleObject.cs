using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : GenericMechanism
{

    public override void Activate(bool canOpen)
    {
        if (canOpen )
        {
            if (!isActivated)
            {
                GetComponent<Collider2D>().enabled = true;
                GetComponent<SpriteRenderer>().color = Color.white;
                isActivated = true;
            }
            else
            {
                isActivated = false;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = Color.gray;
            }

        }

    }

    public override bool GetStatus()
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAudio()
    {
        throw new System.NotImplementedException();
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
