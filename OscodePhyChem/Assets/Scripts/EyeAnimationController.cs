using UnityEngine;
using UnityEngine.UI;

public class AutoToggleButton : MonoBehaviour
{
    public Button targetButton; // Reference to the button you want to toggle automatically

    void Start()
    {
        // Check if the button is assigned
        if (targetButton != null)
        {
            // Simulate a click on the button to toggle it once when the scene loads
            targetButton.onClick.Invoke();
        }
        else
        {
            Debug.LogWarning("Target button is not assigned in the AutoToggleButton script.");
        }
    }
}
