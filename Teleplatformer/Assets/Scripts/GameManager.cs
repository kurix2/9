using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//public static int currentScore;
	//public static int highScore;
	public static int currentLevel = 0;
	public static int unlockedLevel;
    [Space]
    //public bool firstTime = true;
    public static int playerProgress = 0;
    private static string savedProgress = "savedProgress";
    //public GameObject hideOnFirst;

    private bool paused;
    public GameObject canvas;

    private void Awake()
    {
        playerProgress = PlayerPrefs.GetInt(savedProgress);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (currentLevel == 0 && playerProgress == 0)
        {
            LoadTutorial();
        }
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
			currentLevel += 1;
			SceneManager.LoadScene (currentLevel);
        if (currentLevel >= playerProgress)
        {
            playerProgress = currentLevel;
            PlayerPrefs.SetInt(savedProgress, playerProgress);
        }
	}

	public static void RestartLevel(){
		SceneManager.LoadScene (currentLevel);
	}

    public static void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public static void SetProgress(int setPlayerProgress)
    {
        playerProgress = setPlayerProgress;
        PlayerPrefs.SetInt(savedProgress, playerProgress);
    }

    public static void CompleteGame()
    {
        currentLevel += 1;
        if (currentLevel >= playerProgress)
        {
            playerProgress = currentLevel;
            PlayerPrefs.SetInt(savedProgress, playerProgress);
        }
        SceneManager.LoadScene(0);
    }
  

    void Update()
    {
        if (currentLevel == 0)
        {
            paused = false;
        }
    }
}