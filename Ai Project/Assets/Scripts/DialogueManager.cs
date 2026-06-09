using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public CharacterManager characterManager;

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
        currentLine++;

        if (currentLine >= dialogueLines.Length)
        {
            Debug.Log("End of dialogue.");
            return;
        }

        StartCoroutine(TypeLine());
    }
}