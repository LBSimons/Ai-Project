using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public GameObject choicePanel;

    public Button choiceButton1;
    public Button choiceButton2;

    public TextMeshProUGUI choiceText1;
    public TextMeshProUGUI choiceText2;

    private int selectedChoice = -1;

    void Start()
    {
        choicePanel.SetActive(false);
    }

    public void ShowChoices(string option1, string option2)
    {
        choicePanel.SetActive(true);

        choiceText1.text = option1;
        choiceText2.text = option2;

        selectedChoice = -1;
    }

    public void SelectChoice(int choice)
    {
        selectedChoice = choice;
        choicePanel.SetActive(false);

        if (choice == 0)
        {
            GameManager.Instance.AddAyaAffection(1);
        }
        else if (choice == 1)
        {
            GameManager.Instance.AddAyaAffection(-1);
        }

        Debug.Log("Player selected: " + choice);
        FindFirstObjectByType<DialogueManager>().ContinueAfterChoice(choice);

    }
    public int GetChoice()
    {
        return selectedChoice;
    }
    public bool ChoicesAreOpen()
    {
        return choicePanel.activeSelf;
    }
}