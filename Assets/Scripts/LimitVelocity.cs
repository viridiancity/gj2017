using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitVelocity : MonoBehaviour
{
   public float maxVelocity;
   Rigidbody2D rb2d;

   // Use this for initialization
   void Start()
   {
      rb2d = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);

   }
}
