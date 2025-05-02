using UnityEngine;
using UnityEngine.UI;

public class LabelToggleAndButtonController : MonoBehaviour
{
    public GameObject[] labels;       // Array to store all label objects
    public Button toggleButton;       // Reference to the UI button
    public GameObject targetPanel;    // Reference to the panel that controls button and label visibility

    private bool labelsVisible;       // Track the visibility state
    private bool buttonInitialState;  // Store the button's initial interactable state

    private void Start()
    {
        // Store the initial interactable state of the button
        buttonInitialState = toggleButton.interactable;

        // Attach the ToggleLabels method to the button's onClick event
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleLabels);
        }

        // Ensure all labels start as hidden and update `labelsVisible`
        labelsVisible = false;
        SetLabelsVisibility(labelsVisible);
    }

    private void Update()
    {
        // Check if the panel is active
        if (targetPanel != null && targetPanel.activeSelf)
        {
            // If the panel is active, hide all labels and disable the button
            SetLabelsVisibility(false);
            toggleButton.interactable = false;
        }
        else
        {
            // If the panel is inactive, restore the button's initial state
            toggleButton.interactable = buttonInitialState;
        }
    }

    // Method to toggle label visibility when panel is not active
    public void ToggleLabels()
    {
        // Only toggle labels if the panel is not active
        if (targetPanel != null && !targetPanel.activeSelf)
        {
            labelsVisible = !labelsVisible;  // Toggle the visibility state
            SetLabelsVisibility(labelsVisible);
        }
    }

    // Helper method to set labels' active state
    private void SetLabelsVisibility(bool isVisible)
    {
        foreach (GameObject label in labels)
        {
            if (label != null)
            {
                label.SetActive(isVisible);
            }
        }
    }
}
