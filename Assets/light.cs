using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public CC cscript;
    public Light l;
    
    void Start()
    {
        //cscript = GetComponent<Car.CC>();
        l = GetComponent<Light>();
    }

    void Update()
    {
        l.enabled = false;
        if (cscript.engine)
        {
            l.enabled = true;
        }
       

    }
}
