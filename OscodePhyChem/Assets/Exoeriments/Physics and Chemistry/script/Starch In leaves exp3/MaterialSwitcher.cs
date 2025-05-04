using UnityEngine;
using System.Collections;

public class CustomMaterialChanger : MonoBehaviour
{
    public GameObject _Object;
    public GameObject _Object2;
    public Material newMaterial;
    public Material newMaterial2;
    private Material originalMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = _Object.GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    public void ChangeMaterial()
    {
        objectRenderer.material = newMaterial;
        
    }
    public void ChangeMaterialSecond()
    {
        _Object2.GetComponent<Renderer>().material = newMaterial2;
    }
}
