using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Deletar : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI data;

    void Start()
    {
        data = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int a = (int) (Time.frameCount / Time.time);
        data.text = a.ToString();
    }
}
