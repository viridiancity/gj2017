using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
   public GameObject explosionPrefab;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         Instantiate(explosionPrefab, transform.position, Quaternion.identity);
      }
   }

}
