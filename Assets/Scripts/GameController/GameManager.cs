﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private int auxScenesQtd = 2;
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetThisScene()
    {

        return SceneManager.GetActiveScene().buildIndex;
    }
    public int NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings == nextScene)
        {
            return 0;
        }

        return nextScene;
    }

    public void ResetScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public int[] GetLevels()
    {
        int sceneQtd = SceneManager.sceneCountInBuildSettings;

        int[] levels = new int[sceneQtd - auxScenesQtd];

        for(int i = auxScenesQtd; i < sceneQtd; i++)
        {
            levels[i - auxScenesQtd] = i;
        }

        return levels;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
