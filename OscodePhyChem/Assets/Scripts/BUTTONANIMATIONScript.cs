using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerClickHandler
{
    private Vector3 originalScale;
    private Color originalColor;
    public Color pressedColor = Color.gray; // Set desired color
    private bool isPressed = false;
    private UnityEngine.UI.Image buttonImage; // Explicit reference

    void Start()
    {
        originalScale = transform.localScale;
        buttonImage = GetComponent<UnityEngine.UI.Image>();
        if (buttonImage != null)
        {
            originalColor = buttonImage.color;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isPressed = !isPressed;

        if (isPressed)
        {
            transform.localScale = originalScale * 1.1f; // Scale up
            if (buttonImage != null)
                buttonImage.color = pressedColor; // Change color
        }
        else
        {
            transform.localScale = originalScale; // Revert scale
            if (buttonImage != null)
                buttonImage.color = originalColor; // Revert color
        }
    }
}
