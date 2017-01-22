using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
   PlayerScript player;

   private void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

      if (!player)
         Debug.LogError("Player not found");
   }

   void OnTriggerEnter2D(Collider2D collision)
   {
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         if (player.health > 0)
         {
            player.health -= 10;
         }
            
         player.Hit();
         Destroy(collision.gameObject);
      }
   }

}
