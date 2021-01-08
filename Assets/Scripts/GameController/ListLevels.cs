using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ListLevels : MonoBehaviour
{
    [SerializeField] GameObject levelButton;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    private Transform initial_position;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    private void Awake()
    {
        initial_position = transform.GetChild(0);
        gameManager = FindObjectOfType<GameManager>();
        int[] levels = gameManager.GetLevels();
        int levelsUploaded = 0;
        foreach(int i in levels)
        {
            GameObject newButton = Instantiate(levelButton, initial_position);
            newButton.transform.localPosition = new Vector2(levelsUploaded * xOffset, levelsUploaded * yOffset);
            levelsUploaded++;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            newButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { gameManager.ChangeScene(i); });

        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
