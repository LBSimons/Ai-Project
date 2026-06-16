using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string spriteName;
    public string backgroundName;

    [TextArea(3, 10)]
    public string dialogue;

    public bool hasChoice;
    public string choiceOption1;
    public string choiceOption2;

    public int choice1NextLine;
    public int choice2NextLine;
}