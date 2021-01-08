using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    GameManager gameManager;
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
            Destroy(this);
        }
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
