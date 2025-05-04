using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveButtonText : MonoBehaviour
{
    public TMP_InputField userInputField;
    private const string ButtonTextKey = "ButtonText";

    void Start()
    {
        // Load the saved text into the input field when the scene starts
        if (userInputField != null)
        {
            string savedText = PlayerPrefs.GetString(ButtonTextKey, "");
            userInputField.text = savedText;
        }
    }

    public void SaveText()
    {
        if (userInputField != null)
        {
            string userInput = userInputField.text;

            // Save the updated text to PlayerPrefs
            PlayerPrefs.SetString(ButtonTextKey, userInput);
            PlayerPrefs.Save();
        }
    }
}
