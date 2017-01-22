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
   AudioSource audioSrc;

   // Use this for initialization
   void Start()
   {
      audioSrc = GetComponent<AudioSource>();
   }

   // Update is called once per frame
   void Update()
   {

   }
}
