using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of GameObjects to disable/enable
    public Button[] disableButtons; // Array of buttons that will disable the objects
    public Button masterButton; // Button to re-enable the GameObjects
    public Button mainButton; // Main button to enable the master button and objects

    void Start()
    {
        // Disable the master button initially
        masterButton.interactable = false;

        // Add listeners to each disable button to disable objects and the master button when clicked
        foreach (Button btn in disableButtons)
        {
            btn.onClick.AddListener(() => 
            {
                DisableGameObjects();
                masterButton.interactable = true; // Enable master button after disabling objects
            });
        }

        // Add listener to the master button to enable the objects
        masterButton.onClick.AddListener(EnableGameObjects);

        // Add listener to the main button to enable the master button and objects
        mainButton.onClick.AddListener(() =>
        {
            masterButton.interactable = true; // Enable master button
            EnableGameObjects(); // Enable the objects as well
        });
    }

    // Method to disable the GameObjects
    private void DisableGameObjects()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }

    // Method to enable the GameObjects
    private void EnableGameObjects()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(true);
        }
    }
}
