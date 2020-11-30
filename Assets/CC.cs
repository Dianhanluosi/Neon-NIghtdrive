using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    bool clutchin;
    bool ignition;
    bool engine;
    bool throttle;
    bool brake;
    bool upshift;
    bool downshift;

    float gear = 0f;
    float lastgear = 0f;
    float gearratio = 30f;
    float downgearratio = 15f;

    float rpm = 0f;
    float maxrpm = 8500f;
    float minrpm = 0f;
    float rpmdrop = 1500f;
    float torque = 450f;

    float inspeed = 0f;
    float inspeed2 = 0f;
    float speed = 0f;
    float acceleration = 0f;
    float drag = -0.2f;
    float hspr = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setting up bools;
        //clutch
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clutchin = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            clutchin = false;
        }
        //ignition
        if (Input.GetKeyDown(KeyCode.R))
        {
            ignition = true;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ignition = false;
        }
        //start engine;
        if (clutchin && ignition)
        {
            engine = true;
        }
        //engine stall
        else if (gear != 0 && rpm == 0 && !clutchin)
        {
            engine = false;
        }
        //throttle
        if (Input.GetKey(KeyCode.W))
        {
            throttle = true;
        }
        if (Input.GetKey(KeyCode.W) == false)
        {
            throttle = false;
        }
        //brake
        if (Input.GetKey(KeyCode.Space))
        {
            brake = true;
        }
        if (Input.GetKey(KeyCode.Space) == false)
        {
            brake = false;
        }
        //upshift
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upshift = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upshift = false;
        }
        //downshift
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downshift = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            downshift = false;
        }


        print((bool)clutchin);
        print((bool)ignition);
        print((bool)engine);
        print((bool)throttle);
        print((bool)brake);
        print((bool)upshift); 
        print((bool)downshift);
    }
}
