using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image characterImage;

    public void ChangeSprite(string spriteName)
    {
        Sprite sprite = Resources.Load<Sprite>("Characters/" + spriteName);

        if (sprite != null)
        {
            characterImage.sprite = sprite;
        }
        else
        {
            Debug.LogWarning("Sprite not found: " + spriteName);
        }
    }
}