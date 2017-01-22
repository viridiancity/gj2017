using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   private static MusicManager _instance;
   public static MusicManager instance
   {
      get
      {
         if (_instance == null)
            _instance = GameObject.FindObjectOfType<MusicManager>();

         return _instance;
      }
   }

    public AudioClip[] audioClips;
    public AudioClip[] bgm;
    public AudioSource audioSrc;

    private bool playing;

   // Use this for initialization
   void Start()
   {
      audioSrc = GetComponent<AudioSource>();
   }

    public void playTitle()
    {


        audioSrc.clip = audioClips[6];
        audioSrc.Play();
        
    }

    public void playTute()
    {
        playBGM(0);
    }

    public void playWave1()
    {

    }

    public void playWave2()
    {

    }

    // Update is called once per frame
    void Update()
   {

   }

    void playBGM( int i)
    {
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }

        audioSrc.clip = audioClips[i];
        audioSrc.Play();
    }

}
