using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public CharacterManager characterManager;
    public ChoiceManager choiceManager;

    [Header("Dialogue")]
    public DialogueLine [] dialogueLines;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private int currentLine = 0;

    private bool isTyping = false;
    private bool canContinue = false;

    void Start()
    {
        Debug.Log("Start 1");

        characterManager.ChangeSprite("Aya_Happy");

        Debug.Log("Start 2");

        StartCoroutine(TypeLine());

        Debug.Log("Start 3");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (choiceManager != null && choiceManager.ChoicesAreOpen())
            {
                return;
            }

            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine].dialogue;

                isTyping = false;
                canContinue = true;
            }
            else if (canContinue)
            {
                NextLine();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        canContinue = false;

        nameText.text = dialogueLines[currentLine].characterName;

        characterManager.ChangeSprite(
            dialogueLines[currentLine].spriteName
        );

        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLine].dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        canContinue = true;
    }

    void NextLine()
    {
        if (dialogueLines[currentLine].hasChoice)
        {
            dialogueLines[currentLine].hasChoice = false;

            choiceManager.ShowChoices(
                dialogueLines[currentLine].choiceOption1,
                dialogueLines[currentLine].choiceOption2
            );

            return;
        }

        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            Debug.Log("End of dialogue.");
            return;
        }

        StartCoroutine(TypeLine());
    }
    public void ContinueAfterChoice(int choice)
    {
        if (choice == 0)
        {
            currentLine = dialogueLines[currentLine].choice1NextLine;
        }
        else if (choice == 1)
        {
            currentLine = dialogueLines[currentLine].choice2NextLine;
        }

        if (currentLine >= dialogueLines.Length)
        {
            Debug.Log("End of dialogue.");
            return;
        }

        StartCoroutine(TypeLine());
    }
}