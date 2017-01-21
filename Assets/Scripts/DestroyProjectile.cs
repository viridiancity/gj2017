using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{

   // Use this for initialization
   void Start()
   {

   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.transform.tag == "Boat")
         Destroy(gameObject);
   }

}
