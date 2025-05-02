using UnityEngine;
using UnityEngine.UI;

public class ModelToggleController : MonoBehaviour
{
    public GameObject modelA;  // Reference to Model A
    public GameObject modelB;  // Reference to Model B
    public Button toggleButton; // Reference to the toggle button
    public Button masterButton; // Reference to the master button

    void Start()
    {
        // Initially show Model A and hide Model B
        modelA.SetActive(true);
        modelB.SetActive(false);

        // Assign listeners to the buttons
        toggleButton.onClick.AddListener(ToggleModels);
        masterButton.onClick.AddListener(ShowModelA);
    }

    void ToggleModels()
    {
        // If Model A is active, hide it and show Model B
        if (modelA.activeSelf)
        {
            modelA.SetActive(false);
            modelB.SetActive(true);
        }
        else
        {
            // If Model A is not active, hide Model B and show Model A
            modelB.SetActive(false);
            modelA.SetActive(true);
        }
    }

    void ShowModelA()
    {
        // Show Model A and hide Model B
        modelA.SetActive(true);
        modelB.SetActive(false);
    }
}
