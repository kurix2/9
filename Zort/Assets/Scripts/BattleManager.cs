using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public static BattleManager Instance { get; set; }
    [Header("Player Stats")]
    public int playerMxHp = 12;
    public int playerHp;
    public Transform hpHearts;
    public int playerAtk = 2;
    private GameObject AtkText;
    private Text xAtk;
    private int AtkCount;

    [HideInInspector] public bool inBattle = false;
    [HideInInspector] public bool isDead = false;

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

    private void Start()
    {
        AtkCount = playerAtk;
        if (AtkText==null)
        {
            AtkText = GameObject.Find("Atk text");
        }
        xAtk = AtkText.GetComponent<Text>();
        xAtk.text = "x" + playerAtk.ToString();
        print("battle manager started");
    }

    #region PlayerStats

    public void SynchEquipStats(Item itm, bool unequip)
    {
        if (unequip)
        {
            playerAtk -= itm.atkBonus;
            playerMxHp -= itm.hpBonus;
            playerHp -= itm.hpBonus;
        }
        else
        {

        playerAtk += itm.atkBonus;
        playerMxHp += itm.hpBonus;
        playerHp += itm.hpBonus;
        }

        hpHearts.GetComponent<HeartHp>().CalculateHp();
        xAtk.text = "x"+ playerAtk.ToString();
    }

    #endregion

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

    }

    #region Battle Dialogues

    public void StartBattle()
    {
        inBattle = true;
    }

    public void EndBattle()
    {
        inBattle = false;
    }

    public void GenerateBattleStats()
    {
        toHit = Random.Range(1, toHitRange);
    }

    public void AttemptHit(string userInput)
    {
        string missDialogue = "";

        int roll = 0;
        if (int.TryParse(userInput, out roll))
        {
            if(roll != toHit)
            {
                if (roll > toHit)
                {
                    missDialogue = "you aim too <color=red> HIGH </color> and miss!";
                    DialogSystem.Instance.ChangeDialog(missDialogue);

                }else {
                    missDialogue = "you aim too <color=blue> LOW </color> and miss!";
                    DialogSystem.Instance.ChangeDialog(missDialogue);
                }

                AtkCount--;
                if (AtkCount <= 0)
                {
                    DialogSystem.Instance.ChangeDialog(missDialogue + "\n" + enemyName + " attacks you for <color=red>" + enemyAtkDmg + "</color> damage!");
                    TakeDamage();

                    if (playerHp <= 0)
                    {
                        isDead = true;
                        DialogSystem.Instance.ChangeDialog(missDialogue + "\n" + enemyName + "attacks a final time \nand you fall to the ground <color=red>DEAD</color>");
                    }
                    AtkCount = playerAtk;
                }
            }
            else
            {
                currentEnemyHp--;
                if(currentEnemyHp <= 0)
                {
                    DialogSystem.Instance.ChangeDialog("You killed " + enemyName);
                    EndBattle();
                }else
                {
                DialogSystem.Instance.ChangeDialog("You wound " + enemyName +"\nbut it keeps fighting");
                    GenerateBattleStats();
                }
            }
        
        }
    }
    #endregion

    void TakeDamage()
    {
        playerHp -= enemyAtkDmg;
        hpHearts.GetComponent<HeartHp>().CalculateHp();

    }
}
