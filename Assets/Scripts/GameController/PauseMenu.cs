using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private PlayerController playerController;
    // Update is called once per frame
    private void Awake()
    {
        playerController = new PlayerController();
    }

    private void OnEnable()
    {
        playerController.MenuController.Enable();
    }

    private void OnDisable()
    {
        playerController.MenuController.Disable();
    }

    private void Start()
    {
        playerController.MenuController.OpenMenu.started += _ => OpenMenu();
    }

    private void OpenMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

    }

   

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void BackToMenu()
    {
        GameManager.gameManager.ChangeScene(0);
    }

    public void ResetLevel()
    {
        GameIsPaused = false;
        GameManager.gameManager.ResetScene();
        Resume();

    }


    public void QuitGame()
    {
        GameManager.gameManager.QuitGame();
    }

    void Update()
    {
        
    }
}
