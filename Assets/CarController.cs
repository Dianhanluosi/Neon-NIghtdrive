using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody car;

    bool clutchin;
    bool engine = false;

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

    AudioClip m_StartEngine;
   
    // Start is called before the first frame update
    void Start()
    {
        //car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inspeed = 0f;
        speed = 0f;
        acceleration = 0f;
       // drag = -0.2f;

        //start engine
        if (Input.GetKeyDown(KeyCode.R))
        {
          engine = ! engine;
        }
        //engine stall
        else if (gear != 0 && rpm == 0 && !clutchin )
        {
            engine = false;
        }

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
                if (lastgear <= 0f)
                {
                    lastgear = 0f;
                }
                gear -= 1f;
                //downshift rpm rise
                if (gear != 0f)
                {
                    if (rpm != 0f)
                    {
                            rpm += rpmdrop;
                    }
                }
                //setting lowest gear, can only down shift back to -1 when rpm is 0
               /* if (rpm != 0f)
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
                }*/


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
        if (gear <= 0f)
        {
            gear = 0f;
        }
        if (gear >= 6f)
        {
            gear = 6f;
        }

        //press W to increase rpm
        //release W to drop rpm
        if (engine == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
                {
                    rpm += (torque / (gear * gearratio));
                }

                if (gear == 0f)
                {
                    rpm += (torque / (gearratio));
                }

            }

            if (Input.GetKey(KeyCode.W) == false)
            {
                if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
                {
                    rpm -= (torque / (gear * downgearratio));
                }

                if (gear == 0f)
                {
                    rpm -= (torque / downgearratio);
                }

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
        //positive acceleration when gear > 0 and rpm > 1000, when w is down;
        //no acc when gear = 0;

         if (Input.GetKey(KeyCode.W))
         {
             if (gear != 0f)
             {
                 acceleration = hspr / rpm;
             }
             else if (gear == 0f)
             {
                 acceleration = 0f;
             }
         }

         else if (Input.GetKey(KeyCode.W) == false)
         {
             acceleration = 0f;
         }

      

        //setting up speed
        //inspeed += acceleration;
        inspeed += ((acceleration * (rpm / 100)));
        // inspeed += acceleration;
        // inspeed += drag;
        speed = inspeed;
        speed += drag;



        //setting up limits for speed and inspeed;
        if (speed >= 2f)
        {
            speed = 2f;
        }
        if (speed <= 0f)
        {
            speed = 0f;
        }
        if (inspeed >= 5f)
        {
            inspeed = 5f;
        }

        //setting up movement
        if (engine == true)
        {
            //car.AddForce(transform.forward * acceleration);
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }

        //setting up brake and slow down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            drag = -2f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            drag = -0.2f;
        }




        // print(((bool)clutchin));
        print((bool)engine);
        print(((float)gear));
        // print(((int)lastgear));
        // print(((int)rpmdrop));
        print((float)rpm);
        print(((float)inspeed));
        print(((float)acceleration));
        print((float)speed);
        //print((float)drag);
       // print(((int)speed));
       

    }
}
