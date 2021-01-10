using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == (int) LayersTypes.PLAYER || collision.gameObject.layer == (int)LayersTypes.YANG ||
            collision.gameObject.layer == (int)LayersTypes.YIN)
        {
            GameManager.gameManager.ResetScene();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
