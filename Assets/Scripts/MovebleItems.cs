using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebleItems : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody2D boxRigidbody;
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
            boxRigidbody.gravityScale = 0;
            velocity = boxRigidbody.velocity;
            boxRigidbody.velocity = Vector2.zero;
        }
        else
        {
            print("caia");
            boxRigidbody.gravityScale = 1;
            boxRigidbody.velocity = velocity;
        }

}
}
