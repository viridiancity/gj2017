﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
   public GameObject wavePrefab;
    float mag = 150f;
   // Use this for initialization
   void Start()
   {
        pressedthresh = 0.3f;
        chargemaxtime = 1.5f;
   }
    private bool pressed;
    private float pressedtime;
    private float pressedthresh;
    private float chargemaxtime;
    private float pmax;
    private float pthresh;
    // Update is called once per frame
    void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
        if ( pressed) {

            Debug.Log("Fire sustained .. adding deltatime ..");
            //pressedtime = Time.time;

        } else {

            Debug.Log("Fire pressed .. ");
            
            pressed = true;
            pressedtime = Time.time;
            pthresh = pressedtime + pressedthresh;
            pmax = pressedtime + chargemaxtime;
        }

      } else if (Input.GetButtonUp("Fire1")) {
          float ptime = Time.time;
          Debug.Log("Fire released .. ");
          if (ptime <= pthresh) { // normal pulse
                Debug.Log("normal pulse");

                instantiatewave("normal");

          } else { // charged pulse
              // note: add a bit of screenshake for max charge
              Debug.Log("Charged pulse .. ");
            
              Vector3 instantiatePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
              instantiatePosition = new Vector3(instantiatePosition.x, instantiatePosition.y, 0f);
              float mag = ptime - pthresh;
              GameObject w = wavePrefab;
              if ( mag > 0) {
                // held time maxed out charge
                instantiatewave( "MAX" );//

              } else {
                // negative time - mid-charge pulse
                instantiatewave("partial");//

              }
          
          }
          
          pressedtime = 0;
          pressed = false;
            
      }

    }

    private void instantiatewave(string s)
    {
        Vector3 instantiatePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        instantiatePosition = new Vector3(instantiatePosition.x, instantiatePosition.y, 0f);
        if (s == "normal")
        {
            Instantiate(wavePrefab, instantiatePosition, transform.rotation);
        } else if ( s == "MAX")
        {
            wavePrefab.GetComponent<PointEffector2D>().forceMagnitude = wavePrefab.GetComponent<PointEffector2D>().forceMagnitude * 6;
            Instantiate(wavePrefab, instantiatePosition, transform.rotation);
            wavePrefab.GetComponent<PointEffector2D>().forceMagnitude = 150;
        }
        else if ( s == "partial")
        {
            wavePrefab.GetComponent<PointEffector2D>().forceMagnitude = wavePrefab.GetComponent<PointEffector2D>().forceMagnitude * ((mag % 3) + 1);
            Instantiate(wavePrefab, instantiatePosition, transform.rotation);
            wavePrefab.GetComponent<PointEffector2D>().forceMagnitude = 150;
        }
        else
        {
            Debug.Log("wtf lol");
        }
    }

   public void DestroyWave()
   {
      Debug.Log("Wave Destroying");
      Destroy(gameObject);
   }
}