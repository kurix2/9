using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//public static int currentScore;
	//public static int highScore;
	public static int currentLevel = 0;
	public static int unlockedLevel;

    private bool paused;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool Paused
    {
        get { return paused; }
    }

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return GameManager.instance;
        }

        set
        {
            instance = value;
        }
    }

    public void PauseGame()
    {
        paused = !paused;
    }

	public static void CompleteLevel()
	{
			
		//if (currentLevel <= 2) {
			currentLevel += 1;
			SceneManager.LoadScene (currentLevel);
		//} else {SceneManager.LoadScene (0);}
	}

	public static void RestartLevel(){
		SceneManager.LoadScene (currentLevel);
	}
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (currentLevel == 0)
        {
            paused = false;
        }
    }
}