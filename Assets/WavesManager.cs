using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
   public GameObject wavePrefab;

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         Debug.Log("Hello!?");
         Instantiate(wavePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
      }
   }

   public void DestroyWave()
   {
      Debug.Log("Wave Destroying");
      Destroy(gameObject);
   }
}
