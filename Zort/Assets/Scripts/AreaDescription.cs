using UnityEngine;
using System.Collections;

[System.Serializable]
public class AreaDescription : MonoBehaviour {

    [TextArea(1,4)]
    public string[] areaTexts; //TODO combine this with the areaText below if possible

    public bool isDanger = false;

    [Space]
    [Header("Battle Stats")]
    public int battleStart;
    public string enemyName;
    public int enemyHp;
    public int enemyTohitRange;
    public int enemyAtkDmg;
   


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            foreach(string text in areaTexts)
            {
                DialogSystem.Instance.QueueSentence(text);
            }

            //Danger Mode disables movement and generates battle stats
            if (isDanger)
            {
                PlayerController.Instance.ToggleDanger();
                DialogSystem.Instance.SetBattleDialog(battleStart, enemyName, enemyTohitRange);
                //DialogSystem.Instance.BattleDialog(enemyName, enemyTohitRange);
                BattleManager.Instance.GenerateBattleStats(enemyName, enemyTohitRange, enemyHp, enemyAtkDmg);
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
}
