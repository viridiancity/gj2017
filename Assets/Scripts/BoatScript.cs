﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{

   private void OnCollisionEnter2D(Collision2D collision)
   {
      string tag = collision.transform.tag;

      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         EnemyLevelWaveManager.instance.numEnemies = EnemyLevelWaveManager.instance.numEnemies - 1;
         Destroy(gameObject);
      }
   }

}
