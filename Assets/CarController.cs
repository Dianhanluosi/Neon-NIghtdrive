using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    bool clutchin;

    int gear = 0;
    int lastgear = 0;
    int gearratio = 30;
    int downgearratio = 15;

    int rpm = 0;
    int maxrpm = 8500;
    int minrpm = 0;
    int rpmdrop = 1500;
    int torque = 450;

    float inspeed = 0;
    float speed = 0;
    float acceleration = 0;
    int drag = -1;
    int hspr = 2000;
   
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
            rpmdrop = 0;
        }
        else if (gear != lastgear)
        {
            rpmdrop = 1500;
        }

        //switch gear system
        if (clutchin)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //so the sync system would work
                lastgear = gear-2;
                if (lastgear <= -1)
                {
                    lastgear = -1;
                }
                gear -= 1;
                //downshift rpm rise
                if (gear != 0 && gear != -1)
                {
                    if (rpm != 0)
                    {
                            rpm += rpmdrop;
                    }
                }
                //setting lowest gear, can only down shift back to -1 when rpm is 0
                if (rpm != 0)
                {
                    if (gear == -1)
                    {
                        gear = 0;
                    }
                } else if (rpm == 0)
                {
                    if (gear <= -1)
                    {
                        gear = -1;
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
        if (gear <= -1)
        {
            gear = -1;
        }
        if (gear >= 6)
        {
            gear = 6;
        }

        //press W to increase rpm
        if (Input.GetKey(KeyCode.W))
        {
            if (gear == 1 || gear == 2 || gear == 3 || gear == 4 || gear == 5 || gear == 6)
            {
                rpm += (torque / (gear*gearratio));
            }

            if (gear == -1)
            {
                rpm += (torque / (2 * gearratio));
            }

            if (gear == 0)
            {
                rpm += (torque / (gearratio));
            }
           
        }
        //release W to drop rpm
        if (Input.GetKey(KeyCode.W)==false)
        {
            if (gear == 1 || gear == 2 || gear == 3 || gear == 4 || gear == 5 || gear == 6)
            {
                rpm -= (torque / (gear*downgearratio));
            }

            if (gear == -1)
            {
                rpm -= (torque / (2*downgearratio));
            }

            if (gear == 0)
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
        if (gear > 0 && rpm > 1000)
        {
            acceleration = hspr / rpm;
        }
        //no acc when gear = 0
        else if (gear == 0)
        {
            acceleration = 0;
        }
        //negative acc when gear = -1 and rpm> 0
        else if (gear == -1 && rpm > 1000)
        {
            acceleration = -(hspr / rpm);
        }
        
        //X movement using speed

       /* Vector3 position = this.transform.position;
        position.x += acceleration;
        this.transform.position = position;*/

       

       // print(((bool)clutchin));
        print(((int)gear));
       // print(((int)lastgear));
       // print(((int)rpmdrop));
        print(((int)rpm));
        print(((float)acceleration));
       // print(((int)speed));
       

    }
}
