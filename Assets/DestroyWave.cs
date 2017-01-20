using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWave : MonoBehaviour
{

   public void DestroyWaveAfterAnimation()
   {
      Debug.Log("Wave Destroying");
      Destroy(gameObject);
   }
}
