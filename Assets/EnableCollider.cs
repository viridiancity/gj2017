using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour
{
   public float delay = 0.1f;

   // Use this for initialization
   void Start()
   {
      StartCoroutine(DelayedEnableCollider());
   }

   IEnumerator DelayedEnableCollider()
   {
      yield return new WaitForSeconds(delay);

      GetComponent<PolygonCollider2D>().enabled = true;
   }
}
