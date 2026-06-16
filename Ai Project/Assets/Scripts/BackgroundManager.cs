using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImage;

    void Start()
    {
        ChangeBackground("classroom");
    }

    public void ChangeBackground(string backgroundName)
    {
        Sprite bg = Resources.Load<Sprite>("Backgrounds/" + backgroundName);

        if (bg != null)
        {
            backgroundImage.sprite = bg;
        }
        else
        {
            Debug.LogWarning("Background not found: " + backgroundName);
        }
    }
}