using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{
    public GameObject[] models; // Array to hold references to the models
    public Button[] buttons;    // Array to hold references to the buttons
    public Button masterButton; // Reference to the master button

    void Start()
    {
        // Assign listeners to each button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Local copy of the loop variable
            buttons[i].onClick.AddListener(() => ShowModel(index));
        }

        // Assign listener to the master button
        masterButton.onClick.AddListener(ShowAllModels);

        // Initially show all models
        ShowAllModels();
    }

    void ShowModel(int index)
    {
        // Hide all models
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        // Show the selected model
        if (index >= 0 && index < models.Length)
        {
            models[index].SetActive(true);
        }
    }

    void ShowAllModels()
    {
        // Show all models
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(true);
        }
    }
}
