using UnityEngine;
using TMPro;
using cakeslice;

public class Viewtoggler : MonoBehaviour
{
    [SerializeField] private GameObject[] fullview;
    [SerializeField] private GameObject[] halfview;
    [SerializeField] private BoxCollider bunsencollider;
    [SerializeField] private TextMeshProUGUI temptext;
    [SerializeField] GameObject interacticetext;
    private void Start()
    {
        foreach (GameObject objects in fullview)
        {
            objects.SetActive(true);
        }
        foreach (GameObject objects in halfview)
        {
            objects.SetActive(false);
        }
        bunsencollider.enabled = false;
        temptext.enabled = false;
    }

    public void FullView()
    {

        foreach (GameObject objects in fullview)
        {
            objects.SetActive(true);
        }
        foreach (GameObject objects in halfview)
        {
            objects.SetActive(false);
        }
    }
    public void HalfView()
    {

        foreach (GameObject objects in fullview)
        {
            objects.SetActive(false);
        }
        foreach (GameObject objects in halfview)
        {
            objects.SetActive(true);
        }
    }
    public void BunsenColliderActive()
    {
        bunsencollider.enabled = true;
        temptext.enabled = true;
        interacticetext.SetActive(true);
    }

    public void InteractivetextEnable()
    {
        interacticetext.SetActive(false);
    }
}
