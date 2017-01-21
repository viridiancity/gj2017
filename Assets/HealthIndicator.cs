using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
   public PlayerScript playerScript;
   Image image;

   void Start()
   {
      image = GetComponent<Image>();
   }

   void Update()
   {
      image.fillAmount = playerScript.health / 100f;
   }
}
