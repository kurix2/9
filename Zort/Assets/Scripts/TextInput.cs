using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    void Awake()
    {
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {

        if (BattleManager.Instance.inBattle)
        {
            if (BattleManager.Instance.isDead)
            {
                DeadDialogue(userInput);
            }
            BattleManager.Instance.AttemptHit(userInput);
        }
        else
        {
            userInput = userInput.ToLower();
            if (DialogSystem.Instance.itemDilema || DialogSystem.Instance.hiddenDilema)
            {
                OptionCommands(userInput);
            }
            else
            {
            CommandWords(userInput);

            }
        }

        inputField.text = null;
        inputField.ActivateInputField();
    } 

    void CommandWords(string input)
    {
        switch (input)
        {
            case "":
                        DialogSystem.Instance.NextSentence();
                        break;
               
           //TODO possibly add more command words here in the future
            default:
                DialogSystem.Instance.DisplayDescription("please respond with 「yes」,「no」or 「enter」");
                break;
        }

    }

    void OptionCommands(string input)
    {

        switch (input)
        {
            case "":
                DialogSystem.Instance.ChangeDialog("Please choose an option");
                break;
            case "1":
            case "yes": //testing
                DialogSystem.Instance.OptionInput(1);
                break;
            case "no":
            case "2": //testing
                DialogSystem.Instance.OptionInput(2);
                break;
            default:
                int option;
                if (int.TryParse(input, out option))
                {
                    DialogSystem.Instance.OptionInput(option);

                }
                break;

        }

    }

    void DeadDialogue(string input)
    {
        if (input == "")
        {
            //Reload the scene.
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
