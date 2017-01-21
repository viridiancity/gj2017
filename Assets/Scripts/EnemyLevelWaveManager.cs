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
   public GameObject MineBoatPrefab;

   List<GameObject> boats;
   int enemyWaveNum = 0;
   public int numEnemies = 0;

   void Start()
   {
      boats = new List<GameObject>();
   }

   void Update()
   {
      if (numEnemies <= 0)
      {
         enemyWaveNum++;
         SpawnWave();
      }
   }

   void SpawnWave()
   {
      if (enemyWaveNum == 1)
      {
         Debug.Log("Spawning Wave 1");
         StartCoroutine(DelayedSpawnBoat(BarrelBoatPrefab, 0f));
      }
      else if (enemyWaveNum == 2)
      {
         Debug.Log("Spawning Wave 2");
         StartCoroutine(DelayedSpawnBoat(BarrelBoatPrefab, 3f));
         StartCoroutine(DelayedSpawnBoat(BarrelBoatPrefab, 6f));
         StartCoroutine(DelayedSpawnBoat(BarrelBoatPrefab, 9f));
      }
      else if (enemyWaveNum == 3)
      {
         Debug.Log("Spawning Wave 3");
         StartCoroutine(DelayedSpawnBoat(BarrelBoatPrefab, 3f));
         StartCoroutine(DelayedSpawnBoat(GarbageBoatPrefab, 6f));
         StartCoroutine(DelayedSpawnBoat(MineBoatPrefab, 9f));
      }
   }

   IEnumerator DelayedSpawnBoat(GameObject prefab, float delay)
   {
      numEnemies++;
      yield return new WaitForSeconds(delay);
      GameObject boat = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
      boats.Add(boat);
   }
}
