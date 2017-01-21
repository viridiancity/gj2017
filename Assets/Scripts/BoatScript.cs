using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
   public GameObject BoatsplosionPrefab;

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

         Vector3 instantiatePos = new Vector3(transform.position.x, transform.position.y + 1.15f, 0f);
         Instantiate(BoatsplosionPrefab, instantiatePos, Quaternion.identity);
         Destroy(gameObject);
      }
   }

}
