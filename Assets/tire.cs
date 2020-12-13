using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire : MonoBehaviour
{
    public CC ct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(ct.tire, 0, 0);
    }
}
