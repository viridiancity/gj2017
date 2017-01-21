using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelWaveManager : MonoBehaviour
{
   private static EnemyLevelWaveManager _instance;
   public static EnemyLevelWaveManager instance
   {
      get
      {
         if (_instance == null)
            _instance = GameObject.FindObjectOfType<EnemyLevelWaveManager>();

         return _instance;
      }
   }
   public Transform spawnPosition;
   public GameObject BarrelBoatPrefab;
   public GameObject GarbageBoatPrefab;

   List<BoatScript> boats;
   int enemyWaveNum = 1;

   void Start()
   {

   }

   void Update()
   {

   }

   void SpawnWave1()
   {

   }

   IEnumerator DelayedSpawnBoat(GameObject prefab, float delay)
   {
      yield return new WaitForSeconds(delay);

   }
}
