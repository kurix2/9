using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public static BattleManager Instance { get; set; }
    public InputField inputField;

    private string enemyName;
    private int toHit;
    private int toHitRange;
    private int currentEnemyHp;
    private int enemyAtkDmg;

    void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
        }else { Instance = this; }
    }

    public void GenerateBattleStats(string name, int hitRng, int enemyHp, int AtkDmg)
    {
        //stats
        enemyName = name;
        print("You are fighting a " + enemyName);
        toHitRange = hitRng;
        toHit = Random.Range(1, toHitRange);
        currentEnemyHp = enemyHp;
        print("enemy Hp is " + currentEnemyHp);
        enemyAtkDmg = AtkDmg;
        print("enemy Attack dmg is " + enemyAtkDmg);

        //force input
        inputField.ActivateInputField();
    }

    public void GenerateBattleStats()
    {
        toHit = Random.Range(1, toHitRange);
    }

    public void AttemptHit(string userInput)
    {
        int roll = 0;
        if (int.TryParse(userInput, out roll))
        {
            if(roll != toHit)
            {
                if (roll > toHit)
                {
                    DialogSystem.Instance.ChangeDialog("lower");

                }else {

                    DialogSystem.Instance.ChangeDialog("higher");
                }
            }
            else
            {
                currentEnemyHp--;
                if(currentEnemyHp <= 0)
                {
                DialogSystem.Instance.ChangeDialog("You killed the " + enemyName);
                    PlayerController.Instance.ToggleDanger();
                }else
                {
                DialogSystem.Instance.ChangeDialog("You wound the " + enemyName +"\nbut it keeps fighting");
                    GenerateBattleStats();
                }
            }
        
        }
    }

	
}
