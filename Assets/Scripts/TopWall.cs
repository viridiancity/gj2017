using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
   { 
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         Destroy(collision.gameObject);
      }
   }
}
