using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMechanism : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected bool needKey;
    [SerializeField] protected bool isActivated;
    protected AudioManager audioManager;

    public abstract void Activate(bool canOpen);

    public abstract bool GetStatus();

    public abstract void PlayAudio();
}
