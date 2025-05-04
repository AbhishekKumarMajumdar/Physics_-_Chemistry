using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateButtonText : MonoBehaviour
{
    // Reference to the TMP_InputField where the user enters text
    public TMP_InputField userInputField;

    // Reference to the Button whose text will be updated
    public Button targetButton;

    // Reference to the TMP_Text component of the Button
    private TMP_Text buttonText;

    // Key for saving the button text in PlayerPrefs
    private const string ButtonTextKey = "ButtonText";

    void Start()
    {
        // Get the TMP_Text component from the Button
        if (targetButton != null)
        {
            buttonText = targetButton.GetComponentInChildren<TMP_Text>();
        }

        // Load the saved text from PlayerPrefs
        LoadButtonText();

        // Add a listener to update the button text when the input field value is submitted
        if (userInputField != null)
        {
            userInputField.onEndEdit.AddListener(UpdateAndSaveButtonText);
        }
    }

    // Method to update the button text and save it
    public void UpdateAndSaveButtonText(string userInput)
    {
        if (buttonText != null)
        {
            buttonText.text = userInput;

            // Save the updated text to PlayerPrefs
            PlayerPrefs.SetString(ButtonTextKey, userInput);
            PlayerPrefs.Save();
        }
    }

    // Method to load the saved text from PlayerPrefs
    private void LoadButtonText()
    {
        if (buttonText != null)
        {
            // Load the text from PlayerPrefs, or use a default value if not found
            string savedText = PlayerPrefs.GetString(ButtonTextKey, "Default Button Text");
            buttonText.text = savedText;

            // Set the input field text to match the loaded text
            if (userInputField != null)
            {
                userInputField.text = savedText;
            }
        }
    }
}
