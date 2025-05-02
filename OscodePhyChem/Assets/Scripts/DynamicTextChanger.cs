

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class TextData
{
    public string mainText;
    public string subText;
}

public class DynamicTextChanger : MonoBehaviour
{
    public TMP_Text mainText;            // Reference to the main TextMeshPro text component
    public TMP_Text subText;             // Reference to the sub TextMeshPro text component
    public Button[] buttons;             // Array to hold the buttons

    public List<TextData> textDataList;  // List to hold text data

    void Start()
    {
        if (buttons.Length != textDataList.Count)
        {
            Debug.LogError("The number of buttons must match the number of text data entries.");
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture index for the lambda expression
            buttons[i].onClick.AddListener(() => ChangeText(index));
        }
    }

    // Method to change the text
    void ChangeText(int index)
    {
        if (index < 0 || index >= textDataList.Count)
        {
            Debug.LogError("Index out of range.");
            return;
        }

        mainText.text = textDataList[index].mainText;
        subText.text = textDataList[index].subText;
    }
}
