using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffectAlt : MonoBehaviour, IPointerClickHandler
{
    private Vector3 initialScale;
    private Color defaultColor;
    public Color activeColor = Color.gray;
    private bool toggled = true;
    private UnityEngine.UI.Image btnImage; // Explicit namespace

    void Awake()
    {
        initialScale = transform.localScale;
        btnImage = GetComponent<UnityEngine.UI.Image>(); // Explicit namespace
        if (btnImage != null)
        {
            defaultColor = btnImage.color;
            btnImage.color = activeColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        toggled = !toggled;

        if (toggled)
        {
            transform.localScale = initialScale * 1.1f;
            if (btnImage != null)
                btnImage.color = activeColor;
        }
        else
        {
            transform.localScale = initialScale;
            if (btnImage != null)
                btnImage.color = defaultColor;
        }
    }
}
