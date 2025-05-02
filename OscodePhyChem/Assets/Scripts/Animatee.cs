using UnityEngine;

public class Animatee : MonoBehaviour
{
    private Animator animator; // Animator component
    private bool isSecondAnimation = false; // Track which animation is playing

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // This function will be triggered by the button
    public void ToggleAnimation()
    {
        // Toggle the boolean value
        isSecondAnimation = !isSecondAnimation;

        // Set the boolean parameter in the Animator to switch animations
        animator.SetBool("isPlayingSecondAnimation", isSecondAnimation);
    }
}
