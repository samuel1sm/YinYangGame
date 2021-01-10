using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float increaseTime;
    [SerializeField] private float intensity;
    [SerializeField] float maxTime;
    [SerializeField] private int[] ableToClickInt;


    private EndLevelController endLevelController;
    private SpriteRenderer sprite;
    private Material material;
    private Color previousColor;
    private float count;
    private AudioSource teleportAudio;
    private void Awake()
    {
        count = 0;
        teleportAudio = GetComponent<AudioSource>();
        endLevelController = FindObjectOfType<EndLevelController>();
        sprite = GetComponent<SpriteRenderer>();
        material = sprite.material;
        previousColor = material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (VerifyMask(collision))
        {

        StartCoroutine("ChangeLevel");
        }
    }

    private bool VerifyMask(Collider2D collision)
    {
        foreach (int i in ableToClickInt)
        {
            if (collision.gameObject.layer == i)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (VerifyMask(collision))
        {
            teleportAudio.Stop();
            StopCoroutine("ChangeLevel");
            count = 0;
            material.SetVector("_Color", previousColor);
        }

    }


    IEnumerator ChangeLevel()
    {
        teleportAudio.Play();
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
