using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string spriteName;

    [TextArea(3, 10)]
    public string dialogue;
}