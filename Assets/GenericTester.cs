using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTester : MonoBehaviour
{
   Rigidbody2D rb2d;

   // Use this for initialization
   void Start()
   {
      rb2d = GetComponent<Rigidbody2D>();
      rb2d.AddForce(new Vector2(35f, 100f));
   }

   // Update is called once per frame
   void Update()
   {
   }
}
