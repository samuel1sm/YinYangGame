using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    [SerializeField] private float boxSpawnTime;
    [SerializeField] private float boxMaxQtd;
    [SerializeField] private GameObject box;
    void Start()
    {
        StartCoroutine(SpawnBoxes());
    }

    IEnumerator SpawnBoxes()
    {
        while (true)
        {
            yield return new WaitUntil(()=> transform.childCount < boxMaxQtd);
            yield return new WaitForSeconds(boxSpawnTime);
            GameObject go = Instantiate(box, transform);
            go.transform.localPosition = Vector3.zero;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
