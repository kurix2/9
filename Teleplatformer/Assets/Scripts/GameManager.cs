using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//public static int currentScore;
	//public static int highScore;
	public static int currentLevel = 0;
	public static int unlockedLevel;


	public static void CompleteLevel()
	{
			
		if (currentLevel <= 2) {
			currentLevel += 1;
			SceneManager.LoadScene (currentLevel);
		} else {
			SceneManager.LoadScene (0);
		}
	}

	public static void RestartLevel(){
		SceneManager.LoadScene (currentLevel);
	}
}