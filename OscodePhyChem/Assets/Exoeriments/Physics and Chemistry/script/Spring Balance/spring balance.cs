using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    private Slider mSlider;

    public GameObject Box;

    void Start()
    {
        mSlider = GetComponent<Slider>();
    }

    public void ApplyAnimation()
    {
        if (Box != null)
        {
            Animator animator = Box.GetComponent<Animator>();
            if (animator)
            {
                animator.SetFloat("animationvalue", mSlider.value);
            }
        }
    }
}