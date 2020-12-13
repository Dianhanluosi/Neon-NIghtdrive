using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelRotate : MonoBehaviour
{
    public CC wheel;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(20, 90, 0);
        if (wheel.left && !wheel.atleft)
        {

            transform.rotation = Quaternion.Euler(20, 90, 20);
        }
        if (wheel.right && !wheel.atright)
        {
            transform.rotation = Quaternion.Euler(20, 90, -20);

        }
    }
}
