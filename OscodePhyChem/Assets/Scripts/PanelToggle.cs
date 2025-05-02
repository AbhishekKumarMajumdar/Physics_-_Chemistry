using UnityEngine;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject panel; // The panel to be toggled
    public Button[] openButtons; // Array to hold the 10 buttons that open the panel
    public Button[] closeButtons; // Array to hold the 2 buttons that close the panel

    void Start()
    {
        // Ensure the panel is initially inactive
        panel.SetActive(false);

        // Add listeners to each open button to open the panel
        foreach (Button button in openButtons)
        {
            button.onClick.AddListener(OpenPanel);
        }

        // Add listeners to each close button to close the panel
        foreach (Button button in closeButtons)
        {
            button.onClick.AddListener(ClosePanel);
        }
    }

    void OpenPanel()
    {
        panel.SetActive(true);
    }

    void ClosePanel()
    {
        panel.SetActive(false);
    }
}
