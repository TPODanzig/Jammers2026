using UnityEngine;
using UnityEngine.UI;

public class SpriteMatchGame : MonoBehaviour
{
    public Image targetImage; // de sprite die bovenaan staat
    public Button[] buttons; // de buttons die je moet matchen
    public Sprite[] sprites; // alle mogelijke sprites
    private Sprite currentTarget;

    void Start()
    {
        SetupButtons();
        SetRandomTarget();
    }

    void SetupButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // belangrijke trick voor closures
            buttons[i].onClick.AddListener(() => CheckMatch(index));
            buttons[i].image.sprite = sprites[i]; // zet sprite op de button
        }
    }

    void SetRandomTarget()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        currentTarget = sprites[randomIndex];
        targetImage.sprite = currentTarget;
    }

    void CheckMatch(int buttonIndex)
    {
        if (buttons[buttonIndex].image.sprite == currentTarget)
        {
            Debug.Log("Correct!");
            SetRandomTarget(); // nieuwe target
        }
        else
        {
            Debug.Log("Fout! Probeer opnieuw.");
        }
    }
}



