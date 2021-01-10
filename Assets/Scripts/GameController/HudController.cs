using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Go2Menu()
    {
        GameManager.gameManager.ChangeScene(1);
    }

    public void ExitGame()
    {
        GameManager.gameManager.QuitGame();
    }
}
