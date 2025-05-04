using UnityEngine;
using UnityEngine.UI;

public class ToggleObject : MonoBehaviour
{
    // Reference to the UI Button
    public Button toggleButton;

    // Public variable to set the initial state of the GameObject
    public bool isVisibleAtStart = true;

    private void Start()
    {
        // Set the initial visibility based on the isVisibleAtStart variable
        gameObject.SetActive(isVisibleAtStart);

        // Ensure the button is assigned
        if (toggleButton != null)
        {
            // Add a listener to the button's onClick event
            toggleButton.onClick.AddListener(ToggleGameObject);
        }
        else
        {
            Debug.LogError("Toggle Button not assigned.");
        }
    }

    // Method to toggle the active state of the GameObject
    private void ToggleGameObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    // Clean up to avoid memory leaks
    private void OnDestroy()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.RemoveListener(ToggleGameObject);
        }
    }
}
