using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMechanism : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected bool needKey;

    public abstract void Activate(bool canOpen);
 
}
