using UnityEngine;
using UnityEngine.UI;

public class ButtonImageToggle : MonoBehaviour
{
    public Button[] buttons;           // Array to store all buttons
    public Image[] buttonImages;       // Array to store external Image components
    public Sprite defaultSprite;       // Default sprite for resetting other buttons
    public Sprite clickedSprite;       // Sprite for the clicked button

    void Start()
    {
        // Add listeners to handle button clicks
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture index locally to avoid closure issue
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    // Function to handle button clicks
    void OnButtonClick(int clickedIndex)
    {
        // Reset all button images
        for (int i = 0; i < buttonImages.Length; i++)
        {
            if (i != clickedIndex)
            {
                ResetButtonImage(i);
            }
        }

        // Change the image of the clicked button
        SetClickedButtonImage(clickedIndex);
    }

    // Function to reset the image of a button to the default sprite
    void ResetButtonImage(int index)
    {
        if (buttonImages[index] != null)
        {
            buttonImages[index].sprite = defaultSprite;
        }
    }

    // Function to change the image of the clicked button
    void SetClickedButtonImage(int index)
    {
        if (buttonImages[index] != null)
        {
            buttonImages[index].sprite = clickedSprite;
        }
    }
}
