using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameState : MonoBehaviour
{
    [SerializeField] GameObject flames;
    [SerializeField] float timeDelay = 1f;

    void Start()
    {
        flames.SetActive(false);  // Set flames inactive at the start
    }

    // Update is called once per frame
    void Update()
    {
        // Any additional update logic can go here
    }

    // Function to activate flames after a delay
    public void ActivateFlamesWithDelay()
    {
        StartCoroutine(ActivateFlamesCoroutine());
    }

    // Coroutine to handle the delay
    private IEnumerator ActivateFlamesCoroutine()
    {
        yield return new WaitForSeconds(timeDelay);
        flames.SetActive(true);
    }
}
