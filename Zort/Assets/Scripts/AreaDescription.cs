using UnityEngine;
using System.Collections;

[System.Serializable]
public class AreaDescription : MonoBehaviour {

    [TextArea(1, 4)]
    public string[] areaTexts;

    public bool isDanger = false;
    public bool isItem = false;
    public bool isHidden = false;

    [Space]
    public bool hiddenCommand;
    public GameObject objToChange;
    public GameObject objAfterChange;

    [Space]
    public int progressPrereq;
    public int progressOnStart;
    public int progressOnHidden;

    [Space]
    [TextArea(1, 4)]
    public string[] itemTexts;
    public Item item;

    [Space]
    [Header("Hidden Triggers")]
    [TextArea(1, 4)]
    public string[] hiddenTexts;
    public int[] hiddenAnswers;
    public string keyItem;

    [Space]
    [Header("Battle Stats")]
    public string enemyName;
    public int enemyHp;
    public int enemyTohitRange;
    public int enemyAtkDmg;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (progressOnStart > 0)
            {
                int prog = DialogSystem.Instance.gameProgress;
                if (prog < progressOnStart)
                {
                    DialogSystem.Instance.gameProgress = progressOnStart;
                }
            }
            DialogSystem.Instance.SetActiveArea(GetComponent<AreaDescription>());

            foreach (string text in areaTexts)
            {
                DialogSystem.Instance.QueueSentence(text);
            }

            if (isDanger)
            {
                DialogSystem.Instance.PassBattleStats(enemyName, enemyTohitRange);
                BattleManager.Instance.GenerateBattleStats(enemyName, enemyTohitRange, enemyHp, enemyAtkDmg);
            }

            if (isItem)
            {
                DialogSystem.Instance.isItem = true;
            }
            DialogSystem.Instance.NextSentence();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogSystem.Instance.HideDescription();

        }
    }

    #region Hidden Triggers


    public void OpenHiddenTrigger()
    {
        DialogSystem.Instance.SetActiveArea(GetComponent<AreaDescription>());
        DialogSystem.Instance.ClearQueue();

        foreach (string text in areaTexts)
        {
            DialogSystem.Instance.QueueSentence(text);
        }

        if (isDanger)
        {
            DialogSystem.Instance.PassBattleStats(enemyName, enemyTohitRange);
            BattleManager.Instance.GenerateBattleStats(enemyName, enemyTohitRange, enemyHp, enemyAtkDmg);
        }

        if (isItem)
        {
            DialogSystem.Instance.isItem = true;
        }

        DialogSystem.Instance.NextSentence();

    }

    public void ChangeObject()
    {
        if (objAfterChange!=null)
        {
            Instantiate(objAfterChange, this.transform.position, Quaternion.identity);
        }
        if (objToChange!=null)
        {
            Destroy(objToChange);
        }
        else
        {
            print("Object to be destroyed hasn`t been specified for the ChangObject() function");
        }
    }

    #endregion

}
