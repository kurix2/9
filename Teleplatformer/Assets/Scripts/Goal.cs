using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public float moveSpeed = 0.5f;
	public Transform loadTrigger;
    public int newLevel;
    public bool skipsLevel = false;
    public bool finalLevel = false;
    [Space]
    [Header("Debug Options")]
    public bool resetsProgress = false;
    public bool quitsGame = false;

	private bool finish = false;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            if (skipsLevel == true && newLevel > GameManager.playerProgress)
            {
                transform.position = (new Vector3(transform.position.x, transform.position.y - 20, transform.position.z));
                print(gameObject + "'s newLevel is" + newLevel + "& the playerProgress is at " + GameManager.playerProgress);
            }
        }
	
	}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Paused != true)
        {
            if (finish == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, loadTrigger.position, Time.deltaTime * moveSpeed);
            }
            if (transform.position.y >= loadTrigger.position.y - 1)
            {
                if (finalLevel == true)
                {
                    GameManager.CompleteGame();
                }
                else
                {
                    if (skipsLevel == true)
                    {
                        GameManager.RestartLevel();
                    }
                    else
                    {
                        GameManager.CompleteLevel();
                    }
                }
            }
        }
    }

	void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Player") {
            if (quitsGame)
            {
                Debug.Log("quit game");
                PlayerPrefs.SetInt("savedProgress", GameManager.playerProgress);
                Application.Quit();
            }
            else
            {
                if (resetsProgress == true)
                {
                    GameManager.playerProgress = 0;
                    GameManager.SetProgress(0);
                    GameManager.LoadTutorial();
                }
                else
                {
                    if (skipsLevel == true)
                    {
                        GameManager.currentLevel = newLevel;
                    }
                    finish = true;
                }
            }
		}
	}
}