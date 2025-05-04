using UnityEngine;

public class FlameEffect : MonoBehaviour
{
    public float minScale = 1f; // Minimum scale
    public float maxScale = 1.5f; // Maximum scale
    public float speed = 1f; // Speed of scaling
    private Vector3 initialScale; // Initial scale of the object

    void Start()
    {
        initialScale = transform.localScale; // Store the initial scale
    }

    void Update()
    {
        // Calculate the new scale based on a sinusoidal function to create a flickering effect
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1f));

        // Apply the new scale to the object
        transform.localScale = initialScale * scale;
    }
}
