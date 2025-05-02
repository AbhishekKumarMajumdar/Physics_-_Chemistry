using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    public GameObject panel; // Reference to the Panel
    public Button toggleButton; // Reference to the Button

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(TogglePanelVisibility);
        }

        // Ensure the panel is hidden by default
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void TogglePanelVisibility()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
