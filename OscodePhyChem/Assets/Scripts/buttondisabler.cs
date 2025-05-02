using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttondisabler : MonoBehaviour
{
    // Reference to the panel that triggers the button disabling
    public GameObject targetPanel;

    // Reference to the button that needs to be disabled/enabled
    public Button targetButton;

    private bool buttonInitialState;  // To store the button's initial interactable state

    private void Start()
    {
        // Store the initial interactable state of the button
        buttonInitialState = targetButton.interactable;
    }

    private void Update()
    {
        // Check if the panel is active
        if (targetPanel.activeSelf)
        {
            // Disable the button and set it as non-interactable
            targetButton.interactable = false;
        }
        else
        {
            // Enable the button and restore its initial state
            targetButton.interactable = buttonInitialState;
        }
    }
}

