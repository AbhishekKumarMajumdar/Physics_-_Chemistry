using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator;         // Reference to the Animator component
    public string animationClipName;  // Name of the animation clip to control
    public int loopCount = 5;         // Number of times to loop the animation
    public string endStateName = "Idle"; // Name of the state to transition to after looping

    private int currentLoop = 0;      // Tracks the current number of loops
    private bool isPlaying = false;   // Checks if the animation is currently playing

    void Update()
    {
        if (animator == null || string.IsNullOrEmpty(animationClipName)) return;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Check if the animation is playing
        if (stateInfo.IsName(animationClipName))
        {
            if (!isPlaying)
            {
                // Animation has started playing
                isPlaying = true;
                currentLoop = 0;
            }

            // Check the progress of the animation
            if (stateInfo.normalizedTime >= 1.0f)
            {
                currentLoop++;

                if (currentLoop >= loopCount)
                {
                    // Stop the animation if the desired loop count is reached
                    animator.Play(endStateName); // Transition to the end state
                    isPlaying = false;
                }
                else
                {
                    // Restart the animation to loop again
                    animator.Play(animationClipName, 0, 0); // Restart the animation from the beginning
                }
            }
        }
        else
        {
            // If the animation is not playing, reset the state
            isPlaying = false;
        }
    }
}
