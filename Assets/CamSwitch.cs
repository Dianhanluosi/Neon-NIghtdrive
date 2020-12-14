using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public CC start;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public GameObject camera6;
    public GameObject camera7;
    public GameObject camera8;
    public GameObject camera9;
    public GameObject camera10;


    public int cam = 1;

    

    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(false);
        camera5.SetActive(false);
        camera6.SetActive(false);
        camera7.SetActive(false);
        camera8.SetActive(false);
        camera9.SetActive(false);
        camera10.SetActive(false);

    }

    public float timer = 150f;

    void Update()
    {
        if (start.started)
        {
            timer -= Time.deltaTime;

        }
        else
        {
           
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            cam += 1;
        }
        if (cam == 6)
        {
            cam = 1;
        }

        if (timer <= 150 && timer > 135)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 135 && timer > 120)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 120 && timer > 105)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 105 && timer > 90)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);


        }
        if (timer <= 90 && timer > 75)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(true);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);


        }
        if (timer <= 75 && timer > 60)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(true);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 60 && timer > 45)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(true);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 45 && timer > 30)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(true);
            camera9.SetActive(false);
            camera10.SetActive(false);

        }
        if (timer <= 30 && timer > 15)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(true);
            camera10.SetActive(false);

        }
        if (timer <= 15 && timer > 0)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            camera8.SetActive(false);
            camera9.SetActive(false);
            camera10.SetActive(true);

        }
        if (timer <= 0f)
        {
            timer = 165f;


        }

        /*if (cam == 1)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);

        }
        if (cam == 2)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);

        }
        if (cam == 3)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
            camera5.SetActive(false);

        }
        if (cam == 4)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
            camera5.SetActive(false);


        }
        if (cam == 5)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(true);


        }*/
    }
}
