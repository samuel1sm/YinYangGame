using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebleItems : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody2D boxRigidbody;
    private float gravityScale;
    private Color previusColor;
    private bool isActivate;
    public bool IsActivate { get => isActivate; set => isActivate = value; }

    private void Awake()
    {
        IsActivate = false;
        boxRigidbody = GetComponent<Rigidbody2D>();
    }
    public void resetValues(bool activate)
    {

        IsActivate = activate;
        if (activate)
        {
            previusColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = Color.gray;
            boxRigidbody.bodyType = RigidbodyType2D.Static;
            gravityScale = boxRigidbody.gravityScale;
            velocity = boxRigidbody.velocity;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = previusColor;
            boxRigidbody.bodyType = RigidbodyType2D.Dynamic;
            boxRigidbody.gravityScale = gravityScale;
            //boxRigidbody.velocity = velocity;
        }

    }

   

    public bool GetIsHeavy()
    {
        return boxRigidbody.bodyType == RigidbodyType2D.Static;
    }
}
