using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadButtonText : MonoBehaviour
{
    // Reference to the Button whose text will be updated
    public Button targetButton;

    // Reference to the TMP_Text component of the Button
    private TMP_Text buttonText;

    // Key for loading the button text from PlayerPrefs
    private const string ButtonTextKey = "ButtonText";

    void Start()
    {
        // Get the TMP_Text component from the Button
        if (targetButton != null)
        {
            buttonText = targetButton.GetComponentInChildren<TMP_Text>();
        }

        // Load the saved text from PlayerPrefs and set it to the button's text
        if (buttonText != null)
        {
            string savedText = PlayerPrefs.GetString(ButtonTextKey, "Default Button Text");
            buttonText.text = savedText;
        }
    }
}

