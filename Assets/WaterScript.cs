using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         collision.transform.GetComponent<Rigidbody2D>().drag = 1.3f;
         collision.transform.GetComponent<Rigidbody2D>().angularDrag = 2.5f;
         collision.transform.GetComponent<LimitVelocity>().maxVelocity = 28f;
      }
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         collision.transform.GetComponent<Rigidbody2D>().drag = 0f;
         collision.transform.GetComponent<Rigidbody2D>().angularDrag = 0f;
         collision.transform.GetComponent<LimitVelocity>().maxVelocity = 100f;
      }
   }
}
