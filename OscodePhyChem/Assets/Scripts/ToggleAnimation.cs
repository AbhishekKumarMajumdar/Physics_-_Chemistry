using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAnimation : MonoBehaviour
{
    // Animator component
    public Animator animator;

    // Button for toggling the animation
    public Button toggleButton;

    // Boolean to track the current animation state (forward or reverse)
    private bool isReversed = true;

    private void Start()
    {
        // Add listener to the button to toggle the animation
        toggleButton.onClick.AddListener(ToggleAnimationState);
    }

    // Method to toggle the animation
    private void ToggleAnimationState()
    {
        // Toggle the boolean for the reverse state
        isReversed = !isReversed;

        // Set the boolean parameter in the Animator to control the animation
        animator.SetBool("isReversed", isReversed);
    }
}
