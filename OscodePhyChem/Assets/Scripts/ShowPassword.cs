using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPassword : MonoBehaviour
{
    [SerializeField] private TMP_InputField userPassword;
    [SerializeField] private RawImage eyeButtonImage;
    [SerializeField] private Texture showIcon;        
    [SerializeField] private Texture hideIcon;        

    public void ShowUserPassword()
    {
        if (userPassword.contentType == TMP_InputField.ContentType.Password)
        {
            // Switch to showing the password
            userPassword.contentType = TMP_InputField.ContentType.Standard;
            // Update the button image to hide eye texture
            eyeButtonImage.texture = hideIcon;
        }
        else
        {
            // Switch to hiding the password
            userPassword.contentType = TMP_InputField.ContentType.Password;
            // Update the button image to show eye texture
            eyeButtonImage.texture = showIcon;
        }

        // Force the InputField to update
        userPassword.ForceLabelUpdate();
    }
}
