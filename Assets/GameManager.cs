using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject enemyWaveLevelmanager;
   public float delay = 3f;

   public void StartGame()
   {
      Invoke("DelayedStartGame", delay);
   }

   void DelayedStartGame()
   {
      enemyWaveLevelmanager.SetActive(true);
   }

}
