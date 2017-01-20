using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
   PlayerScript player;
   Image image;

   void Start()
   {
      image = GetComponent<Image>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

      if (!player)
         Debug.LogError("Player not found");
   }

   void Update()
   {
      image.fillAmount = player.health / 100f;
   }
}
