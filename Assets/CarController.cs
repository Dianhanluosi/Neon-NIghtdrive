using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    bool clutchin;

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
    float speed = 0f;
    float acceleration = 0f;
    float drag = -1f;
    float hspr = 2000f;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //detect whether the clutch is in or not
        if (Input.GetKeyUp(KeyCode.Q))
        {
            clutchin = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clutchin = true;
        }

        //sync lastgear and gear so cannot drop rpm at 6 nor rise rpm at -1
        if (gear == lastgear)
        {
            rpmdrop = 0f;
        }
        else if (gear != lastgear)
        {
            rpmdrop = 1500f;
        }

        //switch gear system
        if (clutchin)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //so the sync system would work
                lastgear = gear-2f;
                if (lastgear <= -1f)
                {
                    lastgear = -1f;
                }
                gear -= 1f;
                //downshift rpm rise
                if (gear != 0f && gear != -1f)
                {
                    if (rpm != 0f)
                    {
                            rpm += rpmdrop;
                    }
                }
                //setting lowest gear, can only down shift back to -1 when rpm is 0
                if (rpm != 0f)
                {
                    if (gear == -1f)
                    {
                        gear = 0f;
                    }
                } else if (rpm == 0f)
                {
                    if (gear <= -1f)
                    {
                        gear = -1f;
                    }
                }


            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //so the sync system would work
                lastgear = gear + 2;
                if (lastgear >= 6)
                {
                    lastgear = 6;
                }
                gear +=1;
                //upshift rpm drop
                if (gear != 0 && gear != -1)
                {
                    if (rpm != 0)
                    {
                       
                        rpm -= rpmdrop;   
                    }
                }
                //setting highest gear, can only upshift from -1 when rpm is 0
                if (rpm != 0)
                {
                    if (gear <= 0)
                    {
                        gear = -1;
                    }
                }
                else if (rpm == 0)
                {
                    if (gear >= 6)
                    {
                        gear = 6;
                    }
                }
            }
        }
       
        //setting up lowest and highest gear
        if (gear <= -1f)
        {
            gear = -1f;
        }
        if (gear >= 6f)
        {
            gear = 6f;
        }

        //press W to increase rpm
        if (Input.GetKey(KeyCode.W))
        {
            if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
            {
                rpm += (torque / (gear*gearratio));
            }

            if (gear == -1f)
            {
                rpm += (torque / (2f * gearratio));
            }

            if (gear == 0f)
            {
                rpm += (torque / (gearratio));
            }
           
        }
        //release W to drop rpm
        if (Input.GetKey(KeyCode.W)==false)
        {
            if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
            {
                rpm -= (torque / (gear*downgearratio));
            }

            if (gear == -1f)
            {
                rpm -= (torque / (2*downgearratio));
            }

            if (gear == 0f)
            {
                rpm -= (torque / downgearratio);
            }

        }

        //set up max rpm and min rpm;
        if (rpm >= maxrpm)
        {
            rpm = maxrpm;
        }
        if (rpm <= minrpm)
        {
            rpm = minrpm; 
        }

        //setting up acceleration
        //positive acceleration when gear > 0 and rpm > 1000
        if (gear > 0f && rpm > 1000f)
        {
            acceleration = hspr / rpm;
        }
        //no acc when gear = 0
        else if (gear == 0f)
        {
            acceleration = 0f;
        }
        //negative acc when gear = -1 and rpm> 0
        else if (gear == -1f && rpm > 1000f)
        {
            acceleration = -(hspr / rpm);
        }
        
        //X movement using speed

       /* Vector3 position = this.transform.position;
        position.x += acceleration;
        this.transform.position = position;*/

       

       // print(((bool)clutchin));
        print(((float)gear));
       // print(((int)lastgear));
       // print(((int)rpmdrop));
        print(((float)rpm));
        print(((float)acceleration));
       // print(((int)speed));
       

    }
}
