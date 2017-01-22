using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
   public AudioClip[] audioClip;
   AudioSource audioSrc;

   void Awake()
   {
      audioSrc = GetComponent<AudioSource>();
   }

   public void PlaySound()
   {
      audioSrc.PlayOneShot(audioClip[0]);
   }

}
