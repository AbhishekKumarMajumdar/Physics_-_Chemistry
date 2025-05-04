using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsManager : MonoBehaviour
{
    // Array to hold all the models
    public GameObject[] models;

    // Array to hold all the buttons
    public Button[] buttons;

    // Master button
    public Button masterButton;

    void Start()
    {
        // Add listeners to all buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // local copy of i for the closure
            buttons[i].onClick.AddListener(() => ShowModel(index));
        }

        // Add listener to master button
        masterButton.onClick.AddListener(ShowAllModels);

        // Show all models by default
        ShowAllModels();
    }

    // Function to show a specific model and hide others
    void ShowModel(int index)
    {
        for (int i = 0; i < models.Length; i++)
        {
            if (i == index)
            {
                models[i].SetActive(true);
            }
            else
            {
                models[i].SetActive(false);
            }
        }
    }

    // Function to show all models
    void ShowAllModels()
    {
        foreach (GameObject model in models)
        {
            model.SetActive(true);
        }
    }
}
