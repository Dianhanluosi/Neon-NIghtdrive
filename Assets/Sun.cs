using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float speed = 10f;
    private int degree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
