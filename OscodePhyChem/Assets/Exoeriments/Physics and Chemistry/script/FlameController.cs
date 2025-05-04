using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> flames;
    private int currentFlameIndex = 0;
    public void EnableNextFlame()
    {
        if (currentFlameIndex < flames.Count)
        {
            Debug.Log("enabled flame");
            flames[currentFlameIndex].SetActive(true);

            currentFlameIndex++;
        }
        else
        {
            Debug.Log("All flames have been activated!");
        }
    }

    public void ResetFlames()
    {
        foreach (GameObject flame in flames)
        {
            flame.SetActive(false); 
        }
        currentFlameIndex = 0;
    }
}
