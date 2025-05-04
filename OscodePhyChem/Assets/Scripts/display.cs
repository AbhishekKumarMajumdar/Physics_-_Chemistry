using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DisplayProfileImage : MonoBehaviour
{
    public RawImage profileImage;  // UI element to display the profile picture

    void Start()
    {
        // Check if the image data exists in PlayerPrefs
        if (PlayerPrefs.HasKey("ProfileImageData"))
        {
            // Load the Base64 string from PlayerPrefs
            string base64Image = PlayerPrefs.GetString("ProfileImageData");

            // Convert the Base64 string back to a byte array
            byte[] imageBytes = System.Convert.FromBase64String(base64Image);

            // Create a Texture2D from the byte array and assign it to the RawImage
            Texture2D texture = new Texture2D(2,2);
            texture.LoadImage(imageBytes);

            // Display the texture in the RawImage component
            profileImage.texture = texture;
        }
    }
}