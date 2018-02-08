using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {
    public static DialogSystem Instance { get; set; }

    [HideInInspector]
    public bool displayActive = false;

    private Queue<string> sentences;   //testing

    public string description = "no description";
    private GameObject inspectFrame;
    private Text textField;
    private int dangerGage=0;

    [HideInInspector]
    public bool isDanger = false;
    private string enemyName;
    private int dangerPoint;
    private int enemyTohitRange;


	// Use this for initialization
	void Awake () {
        inspectFrame = transform.Find("Inspect Frame").gameObject;
        textField = inspectFrame.transform.Find("DescriptionField").GetComponent<Text>();

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }else { Instance = this; }
	}

    void Start()
    {
        sentences = new Queue<string>(); //testing
    }

    #region Sentence Queue

    public void QueueSentence(string sentence)
    {
        sentences.Enqueue(sentence);
    }

    public void NextSentence() //testing
    {
        if (sentences.Count == 0)
        {
            HideDescription();
            return;
        }
        if (!isDanger)
        {
            string queuedSent = sentences.Dequeue();
            DisplayDescription(queuedSent);
        }
        else
        {
            if (dangerGage < dangerPoint)
            {
                dangerGage++;
                string queuedSent = sentences.Dequeue();
                DisplayDescription(queuedSent);
            }
            else
            {
                BattleDialog(enemyName, enemyTohitRange);
            }
        }
    }

    public void SetBattleDialog(int battleSent, string enemy, int hitRange) 
    {
        isDanger = true;
        dangerPoint = battleSent;
        enemyName = enemy;
        enemyTohitRange = hitRange;
    }

    #endregion

    public void DisplayDescription(string areaText)
    {
        inspectFrame.SetActive(true);
        displayActive = true;
        description = areaText;
        textField.text = description;
    }

    public void HideDescription()
    {
        inspectFrame.SetActive(false);
        displayActive = false;
    }

    public void BattleDialog(string enemy, int hitRange)
    {
        description = "You Encounter a " + enemy + "\nPick a number between 1 and " + hitRange + " to fight";
        textField.text = description;
    }

    public void ChangeDialog(string newDialog)
    {
        description = newDialog;
        textField.text = description;
    }
}
