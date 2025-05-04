using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour
{
    public Animator animator; // Ensure this is assigned in the Inspector
    public string animationTriggerName; // Public variable for the animation trigger name

    public void PlayAnimation()
    {
        if (animator != null)
        {
            if (!string.IsNullOrEmpty(animationTriggerName))
            {
                animator.SetTrigger(animationTriggerName);
            }
            else
            {
                Debug.LogError("Animation trigger name not set in the Inspector");
            }
        }
        else
        {
            Debug.LogError("Animator not assigned in the Inspector");
        }
    }
}
