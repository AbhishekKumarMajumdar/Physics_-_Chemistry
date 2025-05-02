using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObjects : MonoBehaviour
{
    // Game objects to toggle
    public GameObject object1;
    public GameObject object2;

    // Array of normal buttons
    public Button[] buttons;

    // Master toggle button
    public Button masterButton;

    // State tracking variables
    private bool normalButtonCanToggle = true;  // True means normal buttons can toggle the state
    private bool masterToggleState = true;  // True means object1 is active and object2 is inactive

    private void Start()
    {
        // Add listener for each button in the array
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(ToggleNormalButton);
        }

        // Add listener for the master button
        masterButton.onClick.AddListener(ToggleMasterButton);
    }

    // Method to toggle objects for normal buttons
    private void ToggleNormalButton()
    {
        if (normalButtonCanToggle)
        {
            object1.SetActive(!object1.activeSelf);
            object2.SetActive(!object2.activeSelf);
            normalButtonCanToggle = false; // Disable further toggling from normal buttons
        }
    }

    // Method to toggle objects for the master button
    private void ToggleMasterButton()
    {
        // Toggle based on the masterToggleState
        //masterToggleState = !masterToggleState;
        object1.SetActive(masterToggleState);
        object2.SetActive(!masterToggleState);

        // Allow normal buttons to toggle the state again
        normalButtonCanToggle = true;
    }
}