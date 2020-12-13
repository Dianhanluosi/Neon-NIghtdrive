using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSound : MonoBehaviour
{

    public AudioSource audio;

    public AudioClip[] audioClipArray;


   public int num = 0;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Shuffle();

    }

    float timer = 5f;

    void Update()
    {

       timer -= Time.deltaTime;
        if (timer < 0) {
            playSound();
            timer = (audio.time + 5f);

        }
       
        
    }

    

    private void Shuffle()
    {

        for (int i = 0; i < audioClipArray.Length; i++)
        {
            int rnd = Random.Range(0, audioClipArray.Length);
            audio.clip = audioClipArray[rnd];
            audioClipArray[rnd] = audioClipArray[i];
            audioClipArray[i] = audio.clip;
        }
        
    }

    private void playSound()
    {
        if (!audio.isPlaying)
        {
            audio.clip = audioClipArray[num];
            audio.Play();
            numplus();
        }
    }

    private void numplus()
    {
        num++;
        if (num > (audioClipArray.Length-1))
        {
            num = 0;
        }
    }

}
