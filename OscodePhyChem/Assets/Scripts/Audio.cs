using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx;
    // Start is called before the first frame update
    public void Button()
    {
        src.clip = sfx;
        src.Play();
    }
}
