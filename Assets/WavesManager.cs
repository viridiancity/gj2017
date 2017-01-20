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

         Vector3 instantiatePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         instantiatePosition = new Vector3(instantiatePosition.x, instantiatePosition.y, 0f);

         Instantiate(wavePrefab, instantiatePosition, transform.rotation);
      }
   }

   public void DestroyWave()
   {
      Debug.Log("Wave Destroying");
      Destroy(gameObject);
   }
}
