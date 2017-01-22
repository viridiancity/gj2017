using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

   public GameObject gameOverTitle;
   public GameObject restartTitle;

   public GameObject soundManager;

   PlayerScript playerScript;

    void Start()
    {
        soundManager.GetComponent<MusicManager>().playTitle(); 
    }

   public void StartGame()
   {
      playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
      Invoke("DelayedStartGame", delay);
      soundManager.GetComponent<MusicManager>().playTute();
      if (!gameOverTitle)
         Debug.LogError("Game Over title not set");
   }

   void DelayedStartGame()
   {
      enemyWaveLevelManager.SetActive(true);
   }

   public void GameOver()
   {
      enemyWaveLevelManager.SetActive(false);
      gameOverTitle.SetActive(true);
      restartTitle.SetActive(true);
   }

   public void Restart()
   {
      SceneManager.LoadScene(0);
   }

}
