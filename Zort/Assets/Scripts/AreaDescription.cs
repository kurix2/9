using UnityEngine;
using System.Collections;

public class AreaDescription : MonoBehaviour {
    public string areaText;
    public bool isDanger = false;

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
            DialogSystem.Instance.DisplayDescription(areaText);

            //Danger Mode disables movement and generates battle stats
            if (isDanger)
            {
                PlayerController.Instance.ToggleDanger();
                DialogSystem.Instance.BattleDialog(enemyName, enemyTohitRange);
                BattleManager.Instance.GenerateBattleStats(enemyName,enemyTohitRange,enemyHp,enemyAtkDmg);
            }
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
