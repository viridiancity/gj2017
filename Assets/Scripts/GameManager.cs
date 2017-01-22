using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager _instance;
   public static GameManager instance
   {
      get
      {
         if (_instance == null)
            _instance = GameObject.FindObjectOfType<GameManager>();

         return _instance;
      }
   }

   public GameObject enemyWaveLevelManager;
   public float delay = 3f;

   PlayerScript playerScript;

   public void StartGame()
   {
      playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
      Invoke("DelayedStartGame", delay);
   }

   void DelayedStartGame()
   {
      enemyWaveLevelManager.SetActive(true);
   }

   public void GameOver()
   {
      enemyWaveLevelManager.SetActive(false);

   }

}
