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

    private float cont;
    private bool playMain;
    private bool played;
    // Use this for initialization
    void Start()
   {
      audioSrc = GetComponent<AudioSource>();
        playMain = false;
        played = false;
   }

    public void playTitle()
    {


        audioSrc.clip = audioClips[6];
        audioSrc.Play();
        
    }

    public void playTute()
    {
        playBGM(0);
        cont = Time.time + audioClips[0].length;
        bool playMain = true;
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
        if ( playMain && !played)
        {
            if ( Time.time > cont ) {
                playBGM(5);
            }
        }
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
