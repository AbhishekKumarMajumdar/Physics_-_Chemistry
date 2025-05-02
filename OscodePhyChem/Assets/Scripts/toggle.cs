using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public Button toggleRotationButton; // Reference to the button that will toggle rotation
    public Rotate3dModel rotationScript; // Reference to the rotation script attached to the 3D model

    void Start()
    {
        // Add a listener to the button to call the ToggleRotation function when clicked
        toggleRotationButton.onClick.AddListener(ToggleRotation);
    }

    // Function to enable/disable the rotation script
    void ToggleRotation()
    {
        if (rotationScript != null)
        {
            rotationScript.enabled = !rotationScript.enabled; // Toggle the enabled state
        }
    }
}
