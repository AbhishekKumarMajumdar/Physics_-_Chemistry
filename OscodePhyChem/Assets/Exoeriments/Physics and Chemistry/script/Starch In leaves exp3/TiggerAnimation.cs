using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    //[serializeField] string animation;
    [SerializeField] string animtion1;
    [SerializeField] string animtion2;
    [SerializeField] string animtion3;
    [SerializeField] string animtion4;
    [SerializeField] string animtion5;

    void Start()
    {
        // Add onClick listeners to the buttons, only if they are assigned
        if (button1 != null)
            button1.onClick.AddListener(PlayAnimation1);
        if (button2 != null)
            button2.onClick.AddListener(PlayAnimation2);
        if (button3 != null)
            button3.onClick.AddListener(PlayAnimation3);
        if (button4 != null)
            button4.onClick.AddListener(PlayAnimation4);
        if (button5 != null)
            button5.onClick.AddListener(PlayAnimation5);
    }

    void PlayAnimation1()
    {
        animator.SetTrigger(animtion1);
    }

    void PlayAnimation2()
    {
        animator.SetTrigger(animtion2);
    }

    void PlayAnimation3()
    {
        animator.SetTrigger(animtion3);
    }

    void PlayAnimation4()
    {
        animator.SetTrigger(animtion4);
    }

    void PlayAnimation5()
    {
        animator.SetTrigger(animtion5);
    }
}
