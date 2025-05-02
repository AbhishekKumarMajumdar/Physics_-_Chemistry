using UnityEngine;
using UnityEngine.UI;

public class PrefabToggleController : MonoBehaviour
{
    public GameObject prefab; // Reference to the prefab
    private GameObject instantiatedPrefab; // The instantiated prefab
    public Button toggleButton; // The UI Button

    void Start()
    {
        // Add listener to the button to call TogglePrefab when clicked
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(TogglePrefab);
        }

        // Instantiate the prefab but deactivate it initially
        if (prefab != null)
        {
            instantiatedPrefab = Instantiate(prefab);
            instantiatedPrefab.SetActive(false); // Hide the prefab initially
        }
    }

    // Method to toggle the prefab's active state
    public void TogglePrefab()
    {
        if (instantiatedPrefab != null)
        {
            bool isActive = instantiatedPrefab.activeSelf;
            instantiatedPrefab.SetActive(!isActive); // Toggle the prefab

            // Optionally log the state to the console
            //Debug.Log("Prefab is now " + (instantiatedPrefab.activeSelf ? "enabled" : "disabled"));
        }
    }
}
