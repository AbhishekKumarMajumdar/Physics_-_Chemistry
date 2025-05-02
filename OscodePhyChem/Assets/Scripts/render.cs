using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class render : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer line;
    public Transform p1;
    public Transform p2;

    void Start()
    {
     line.positionCount=2;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,p1.position);
        line.SetPosition(1,p2.position);

    }
}
