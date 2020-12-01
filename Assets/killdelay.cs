using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killdelay : MonoBehaviour
{

    public float delay;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Destroy(this.gameObject);
        }
    }
}
