using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirerotate : MonoBehaviour
{
    public CC carc;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
        //gameObject.transform.Rotate(0, 90, 0);


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);

        if (carc.left && !carc.atleft)
        {

            transform.rotation = Quaternion.Euler(0, 80, 0);
        }
        if (carc.right && !carc.atright)
        {
            transform.rotation = Quaternion.Euler(0, 100, 0);

        }


        /* if (carc.left && transform.eulerAngles.y >= -30)
         {
             transform.Rotate(0, -30, 0);

         }

         if (carc.right && transform.eulerAngles.y <= 30)
         {
             transform.Rotate(0, 30, 0);

         }*/



        //if (gameObject.transform.rotation.y)
    }
}
