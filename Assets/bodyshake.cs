using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyshake : MonoBehaviour
{
    public CC carscript;
    public float ym;
    public float zm;

    // Start is called before the first frame update
    void Start()
    {
        //carscript  = GetComponent<CC>();
    }

    // Update is called once per frame
    void Update()
    {

        ym = Random.Range(-0.001f, 0.001f);
        zm = Random.Range(-0.002f, 0.002f);

        

            if (carscript.engine == true)
        {
            // this.transform.position = new Vector3(0, ym,zm);
            Vector3 position = this.transform.position;
            //position.y += ym;
            position.z += zm;
            /*if (this.transform.position.z >= -0.442f)
            {
                position.z = -0.442f;
            }
            if (this.transform.position.z <= -0.444f)
            {
                position.z = -0.444f;
            }
            if (this.transform.position.y >= -0.586f)
            {
                position.z = -0.586f;
            }
            if (this.transform.position.y <= -0.587f)
            {
                position.z = -0.587f;
            }*/
           
            this.transform.position = position;
            //this.transform.position = new Vector3(0, ym, zm);

        }
        else { };
    }
}
