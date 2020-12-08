using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    public bool clutchin;
    public bool ignition;
    public bool engine;
    public bool throttle;
    public bool left;
    public bool right;
    public bool atleft;
    public bool atright;

    public float gear = 0f;
    public float lastgear = 0f;
    public float gearratio = 30f;
    public float downgearratio = 15f;

    public float rpm = 0f;
    public float maxrpm = 8500f;
    public float minrpm = 0f;
    public float rpmdrop = 1500f;
    public float torque = 450f;

    public float acceleration = 0f;
    public float acc2 = 0f;
    public float maxspeed = 150f;
    public float minspeed = 0f;
    public float hspr = 2000f;
    public Rigidbody rb;
    public float mindrag = 0.02f;
    public float maxdrag = 0.05f;

    public AudioClip m_engineOn;
    public AudioClip m_engineOff;
    public AudioClip m_exhaust;

    public float exhuastpitch;
    public float exhuastvolume;

    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {

        //limit fps 
        Application.targetFrameRate = 60;

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
            //play engine startup sound
            //PlayEngineOnSound();
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
        else if (gear != 0f && rpm == 0f && !clutchin)
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
        //left
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKey(KeyCode.A) == false)
        {
            left = false;
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKey(KeyCode.D) == false)
        {
            right = false;
        }



        //setting up for exhuast
        //volume and pitch
        if (engine)
        {
            exhuastvolume = 0.5f;
        }
        else if (!engine)
        {
            exhuastvolume = 0f;
        }
        exhuastpitch = ((rpm / 5000f) + 0.3f);
        //play exhuast sound
        PlayExhaustSound();
        

        //gearing system
        //synch last gear and gear so no rpm drop at 6 and no rise at 0
        if (gear == lastgear)
        {
            rpmdrop = 0f;
        }
        else if (gear != lastgear)
        {
            rpmdrop = 1500f;
        }
        //setting highest and lowest gear
        if (gear <= 0f)
        {
            gear = 0f;
        }
        else if (gear >= 6f)
        {
            gear = 6f;
        }
        //gear switch system
        if (clutchin)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //so sync system would work
                lastgear = gear - 2f;
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
                //setting lowest gear, which is 0
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //so sync works
                lastgear = gear + 2f;
                if (lastgear >= 6f){
                    lastgear = 6f;
                }
                gear += 1f;
                //upshift rpm drop
                if (gear != 0f)
                {
                    if (rpm != 0f)
                    {
                        rpm -= rpmdrop;
                    }
                }
               
            }
        }




        //throttle to increase rpm
        //release throttle to drop rpm
        if (engine)
        {
            if (throttle)
            {
                if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
                {
                    rpm += (torque / (gear * gearratio));
                }
                if (gear == 0f)
                {
                    rpm += (torque / gearratio);
                }
            }
            if (!throttle)
            {
                if (gear == 1f || gear == 2f || gear == 3f || gear == 4f || gear == 5f || gear == 6f)
                {
                    rpm -= (torque / gearratio);
                }
                if (gear == 0f)
                {
                    rpm -= (torque / downgearratio);
                }
            }
        }
        //max and min rpm
        if (rpm >= maxrpm)
        {
            rpm = maxrpm;
        }
        if (rpm <= minrpm)
        {
            rpm = minrpm;
        }




        //setting up acceleration
        //acc only exist when throttle && gear != 0 && rpm > 1000
        //no acc at gear 0
        if (throttle)
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
        else if (!throttle)
        {
            acceleration = 0f;
        }
        //translate acceleration to acc2
        acc2 = (acceleration * (rpm / 350));




        //addforce for movement
        rb.AddForce(acc2, 0, 0, ForceMode.Acceleration);
        //maxspeed for each gear
        maxspeed = gear * 30;
        if (gear == 0)
        {
            maxspeed = 180f;
        }
        //limit speed of rigibody
        if (rb.velocity.magnitude >= maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
        //if engine gets killed car stops- engine brake
        if (!engine)
        {
            rb.velocity = rb.velocity.normalized * minspeed;
        }
        //when throttle min drag
        if (throttle)
        {
            rb.drag = mindrag;
        }
        //when !throttle max drag
        if (!throttle)
        {
            rb.drag = maxdrag;
        }



        //setting up left and right barriers
        if (this.transform.position.z >= -29)
        {
            atleft = true;
        }
        else if (this.transform.position.z < -29)
        {
            atleft = false;
        }
        if (this.transform.position.z <= -43)
        {
            atright = true;
        }
        else if (this.transform.position.z > -43)
        {
            atright = false;
        }
        //left movement and right movement
        if (rb.velocity.magnitude != 0 && left && !atleft)
        {
            Vector3 position = this.transform.position;
            position.z += 0.05f;
            this.transform.position = position;
        }
        else if (atleft)
        {
            Vector3 position = this.transform.position;
            position.z += 0f;
            this.transform.position = position;
        }
        if (rb.velocity.magnitude != 0 && right && !atright)
        {
            Vector3 position = this.transform.position;
            position.z -= 0.05f;
            this.transform.position = position;
        }
        else if (atright)
        {
            Vector3 position = this.transform.position;
            position.z -= 0f;
            this.transform.position = position;
        }



        //print((bool)clutchin);
        //print((bool)ignition);
        //print((bool)engine);
        //print((bool)throttle);
        //print((bool)brake);
        //print((bool)upshift); 
        //print((bool)downshift);
        print((float)gear);
        print((float)rpm);
    }

    /*private void PlayEngineOnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = 2f;
        audio.pitch = 1f;
        //audio.Play();
        audio.clip = m_engineOn;
        audio.PlayOneShot(audio.clip);
        audio.loop = false;
        audio.Play();
    }*/

    private void PlayExhaustSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = exhuastvolume;
        audio.pitch = exhuastpitch;
        //audio.Play();
        audio.clip = m_exhaust;
        //audio.PlayOneShot(audio.clip);
        audio.loop = true;
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }

}
