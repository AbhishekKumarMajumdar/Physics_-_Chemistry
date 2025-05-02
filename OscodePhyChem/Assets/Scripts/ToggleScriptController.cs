using UnityEngine;
using UnityEngine.UI;

public class ToggleScriptController : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject with the script
    public MonoBehaviour scriptToToggle; // The script that will be enabled/disabled
    public Button toggleButton; // The UI Button that will trigger the action

    void Start()
    {
        if (toggleButton != null)
        {
            // Add listener to the button to call ToggleScript when clicked
            toggleButton.onClick.AddListener(ToggleScript);
        }
    }

    // Method to toggle the script on or off
    public void ToggleScript()
    {
        if (scriptToToggle != null)
        {
            // Toggle the script's enabled state
            scriptToToggle.enabled = !scriptToToggle.enabled;

            // Optionally, you can display a message in the console
            Debug.Log(scriptToToggle.GetType().Name + " is now " + (scriptToToggle.enabled ? "enabled" : "disabled"));
        }
    }
}
