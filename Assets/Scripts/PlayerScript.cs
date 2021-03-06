﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
   public int health;

   public Vector3 endScale = new Vector3(1.25f, 1.25f, 1.25f);

   private Vector3 startScale = new Vector3(1, 1, 1);
   private Vector3 current = new Vector3(0, 0, 0);
   private bool charging = false;
   private float lTime = 0;
   private float scharge;
   WavesManager wavesManager;

   public float chargeTime = 1f;
   // Update is called once per frame

   public GameObject wipeoutObj;

   private WipeoutScript wipeoutScript;
   public Vector3 endWPos = new Vector3(1, 6.5f, 1);
   public Vector3 startWPos = new Vector3(1, -11f, 1);
   private bool isWipeout = false;
   private Animator animator;

   private void Start()
   {
      wipeoutScript = wipeoutObj.GetComponent<WipeoutScript>();
      animator = GetComponent<Animator>();
      wavesManager = GetComponent<WavesManager>();
   }

   void Update()
   {
      if (isWipeout)
      {
         if (wipeoutScript.ended == true)
         {
            // wipeout ended, else, in progress
            wipeoutScript.reset();
            isWipeout = false;
            charging = false;
         }

      }
      else if (charging)
      {

         current = Vector3.Lerp(startScale, endScale, lTime);
         transform.localScale = Vector3.Lerp(startScale, endScale, lTime);
         lTime += Time.deltaTime;

      }
      else
      {
         lTime = 0;
         charging = false;

      }
   }

   void OnMouseUp()
   {
      if (scharge + lTime >= scharge + chargeTime)
      {
         // fire epic
         WipeOut();
      }

      transform.localScale = startScale;
      lTime = 0;
      charging = false;

   }

   void OnMouseDown()
   { // shouldn't be able to be called twice with one finger touch inputs without triggering OnMouseUp first .. hopefully
      if (!charging && !isWipeout && wipeoutScript.numKills >= 3)
      {
         charging = true;
         lTime = 0;
         scharge = Time.time;
         transform.localScale = new Vector3(1, 1, 1);
         startScale = new Vector3(1, 1, 1);
      }

   }

   //void OnMouseOver()
   //{ // mouse over not really triggered on touch controls

   //}

   void WipeOut()
   { // fire in WaveManager, or spawn wipeout wave
     //Debug.Log("Wipeout");
      if (!wipeoutObj.GetComponent<WipeoutScript>().isWipeout)
      {
         isWipeout = true;
         wipeoutObj.GetComponent<WipeoutScript>().startWipeout();
      }

   }

   public void ChangeStance(float clickThirds)
   {
      if (clickThirds < 0.33f)
      {
         animator.Play("Left");
      }
      else if (clickThirds < 0.66f)
      {
         animator.Play("Up");
      }
      else
      {
         animator.Play("Right");
      }

   }

   public void Hit()
   {
      if (health > 0)
         animator.Play("Hit");
      else if (health <= 0)
      {
         GameManager.instance.GameOver();
         animator.Play("Death");
         wavesManager.enabled = false;
      }
         
   }

   public void BeginCharging()
   {
      animator.Play("Charging");
   }
}
