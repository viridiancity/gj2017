using UnityEngine;
using System.Collections;

public class RemoveSpriteRenderer : MonoBehaviour
{

   // Use this for initialization
   void Start()
   {
      SpriteRenderer sr = GetComponent<SpriteRenderer>();
      Destroy(sr);
   }
}
