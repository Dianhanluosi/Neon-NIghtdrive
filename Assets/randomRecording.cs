using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRecording : MonoBehaviour
{
    public AudioSource record;

    public AudioClip[] recordArray;

    //public bool done;

    public float timer = 45f;
    public float audtime;

    public int num = 0;


    // Start is called before the first frame update
    void Start()
    {
        record = GetComponent<AudioSource>();
        //Shuffle();

    }


    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            playSound();
            timer = (audtime + 30f);

        }


    }



    private void Shuffle()
    {

        for (int i = 0; i < recordArray.Length; i++)
        {
            int rnd = Random.Range(0, recordArray.Length);
            record.clip = recordArray[rnd];
            recordArray[rnd] = recordArray[i];
            recordArray[i] = record.clip;
        }

    }

    private void playSound()
    {
        if (!record.isPlaying)
        {
            record.clip = recordArray[num];
            record.Play();
            timing();
            numplus();
        }
    }

    void timing()
    {
        audtime = record.clip.length;
    }


    private void numplus()
    {
        num++;
        /*if (num > (recordArray.Length-1))
        {
            num = 0;
        }*/
    }
}
