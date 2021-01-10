using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float increaseTime;
    [SerializeField] private float intensity;
    [SerializeField] float maxTime;

    private EndLevelController endLevelController;
    private SpriteRenderer sprite;
    private Material material;
    private Color previousColor;
    private float count;
    private void Awake()
    {
        count = 0;
        endLevelController = FindObjectOfType<EndLevelController>();
        sprite = GetComponent<SpriteRenderer>();
        material = sprite.material;
        previousColor = material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("ChangeLevel");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("ChangeLevel");
        count = 0;
        material.SetVector("_Color", previousColor);
    }


    IEnumerator ChangeLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseTime);
            count += increaseTime;
            material.SetVector("_Color", material.color * intensity);

            if (count == maxTime)
            {
                Time.timeScale = 0f;
                material.SetVector("_Color", previousColor);
                endLevelController.OpenScreen();
                break;
            }
        }
        

    }
}
