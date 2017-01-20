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
      player.health -= 10;
   }

}
