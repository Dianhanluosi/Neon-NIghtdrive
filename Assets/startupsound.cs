using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startupsound : MonoBehaviour
{
    public CC cac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cac.started &&  cac.engine)
        {
            if (cac.clutchin && cac.ignition)
            {
                startup();
            }

        }
    }

    void startup()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
            cac.started = true;
        }
       
    }

}
