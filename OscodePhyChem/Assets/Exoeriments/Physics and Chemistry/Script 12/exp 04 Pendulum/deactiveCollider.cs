
using cakeslice;
using UnityEngine;

public class deactiveCollider : MonoBehaviour
{
    private Collider touchcollider;


    private void Start()
    {
        touchcollider = GetComponent<Collider>();

        touchcollider.enabled = false;
    }

    public void ActiveOutline()
    {
        touchcollider.enabled = true;
    }
}
