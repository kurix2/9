using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {
    public static DialogSystem Instance { get; set; }
    public InputField inputField;

    [HideInInspector]
    public bool displayActive = false;
    [HideInInspector]
    public bool itemDilema = false;
    [HideInInspector]
    public bool hiddenDilema = false;
    private bool skipHidden = false;

    public int gameProgress = 0;

    private Queue<string> sentences;   //testing

    public string description = "no description";
    private GameObject inspectFrame;
    private Text textField;

    [HideInInspector] public bool isDanger = false;
    [HideInInspector] public bool isItem = false;
    private bool hiddenFound = false;

    private AreaDescription currentArea = null;

    private string enemyName;
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
        sentences = new Queue<string>(); 
    }

    public void SetActiveArea(AreaDescription area)
    {
        currentArea = area;
    }

    public void QueueSentence(string sentence)
    {
        sentences.Enqueue(sentence);
    }

    public void ClearQueue()
    {
        sentences.Clear();
    }

    #region NextSentence

    public void NextSentence() 
    {
 
        if (sentences.Count == 0)
        {
            if (isDanger)
            {
                BattleDialog(enemyName, enemyTohitRange);
                isDanger = false; //TODO maybe change this to be called after battle is complete
            }
            else 
            {
                if (isItem)
                {
                    ItemDialogue();
                }
                else
                {
                    if (currentArea.isHidden && hiddenFound == false && skipHidden == false) 
                    {
                        string key = currentArea.keyItem;
                        if (Inventory.Instance.CheckItem(key) == true || key == null)
                        {
                            if (gameProgress >= currentArea.progressPrereq)
                            {
                               HiddenDialogue();

                            }
                            else { HideDescription(); }

                        }
                        else { HideDescription(); }
                    }
                    else {
                        
                       
                        if (hiddenFound) {
                            Transform hidTrig = currentArea.gameObject.transform.GetChild(0);
                            currentArea = hidTrig.GetComponent<AreaDescription>();
                            HideDescription(); // <used to close first area description before switching to new one.
                            currentArea.OpenHiddenTrigger();
                            hiddenFound = false;
                        } else { HideDescription(); }
                        return;
                    }

                }
            }
        }
        else
        {
            string queuedSent = sentences.Dequeue();
            DisplayDescription(queuedSent);
        }
    }

    #endregion


    #region Dilema Dialogue (item and Hidden)

    void ItemDialogue()
    {
        if (currentArea.itemTexts.Length==0)
        {
            isItem = false;
            GetItem();
            NextSentence();

        }
        else
        {
        itemDilema = true;
        ChangeDialog(currentArea.itemTexts[0]);
        }

    }

    void HiddenDialogue()
    {
        if (currentArea.hiddenTexts.Length==0)
        {
            if (gameProgress < currentArea.progressOnHidden)
            {
                gameProgress = currentArea.progressOnHidden;
            }
            HiddenFound();
            NextSentence();
        }
        else
        {
            hiddenDilema = true;
            ChangeDialog(currentArea.hiddenTexts[0]);
        }
    }

    public void OptionInput(int x)
    {
        if (itemDilema)
        {
        ChangeDialog(currentArea.itemTexts[x]);
        isItem = false;
        itemDilema = false;
            switch (x)
            {
                case 1: //affirmative response (get Item)
                    GetItem();
                    break;
                case 2: //negative response (ignore item, return to default flow)
                    break;
                default:
                    break;
            }
        }
        else if (hiddenDilema)
        {
            ChangeDialog(currentArea.hiddenTexts[x]);
            hiddenDilema=false;
            skipHidden = true;
            for (int i = 0; i < currentArea.hiddenAnswers.Length; i++)
            {
                if (x == currentArea.hiddenAnswers[i])
                {
                    if (gameProgress < currentArea.progressOnHidden)
                    {
                        gameProgress = currentArea.progressOnHidden;
                        skipHidden = false;
                    }
                    HiddenFound();
                }
            }
           
        }
        else {
            print("debug. In dilema dilogue but itemDilema & hiddenDilema are both false");
                }
    }

    private void GetItem()
    {
        Item areaItem = currentArea.GetComponent<AreaDescription>().item;
        Inventory.Instance.AddItem(areaItem);
        currentArea.isItem = false;
    }

    private void HiddenFound()
    {
        hiddenFound = true;
        Inventory.Instance.CheckKeyDelete(currentArea.keyItem);
    }


    #endregion


    public void PassBattleStats(string enemy, int hitRange) 
    {
        isDanger = true;
        enemyName = enemy;
        enemyTohitRange = hitRange;
    }


    public void DisplayDescription(string areaText)
    {
        PlayerController.Instance.ToggleMovement();

        inspectFrame.SetActive(true);
        displayActive = true;
        description = areaText;
        textField.text = description;

        inputField.ActivateInputField(); //Force to Input Field
        inputField.Select();
    }

    public void HideDescription()
    {
        hiddenFound = false;
        skipHidden = false;

        inspectFrame.SetActive(false);
        displayActive = false;
        DialogSystem.Instance.ClearQueue();
        PlayerController.Instance.moveAllowed=true;
        if (currentArea.hiddenCommand)
        {
            currentArea.ChangeObject();
        }
    }

    public void BattleDialog(string enemy, int hitRange)
    {
        description = "You Encounter " + enemy + "\nPick a number between 1 and " + hitRange + " to fight";
        textField.text = description;
        BattleManager.Instance.StartBattle();
    }

    public void ChangeDialog(string newDialog)
    {
        description = newDialog;
        textField.text = description;
    }
}
