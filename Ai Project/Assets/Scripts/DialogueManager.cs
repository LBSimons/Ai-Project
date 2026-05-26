using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [Header("Dialogue")]
    [TextArea(3, 10)]
    public string[] dialogueLines;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private int currentLine = 0;

    private bool isTyping = false;
    private bool canContinue = false;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine];

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

        nameText.text = "Mysterious Girl";
        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLine])
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