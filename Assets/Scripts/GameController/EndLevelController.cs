using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endScreenUI;
    public static bool GameIsEnded = false;


    public void OpenScreen()
    {
        GameIsEnded = true;
        endScreenUI.SetActive(true);
    }

    public void BackToLevelSelctor()
    {
        GameManager.gameManager.ChangeScene(1);
    }

    public void ResetLevel()
    {
        GameManager.gameManager.ResetScene();
    }


    public void NextLevelGame()
    {
        int i = GameManager.gameManager.NextScene();
        GameManager.gameManager.ChangeScene(i);

    }


}
