using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipeoutScript : MonoBehaviour
{
   private Vector3 current;
   public Vector3 endWPos = new Vector3(1, 6.5f, 1);
   public Vector3 startWPos = new Vector3(1, -11f, 1);
   private float lTime = 0;
   public bool isWipeout = false;
   public bool started = false;
   public bool ended = false;

   public Animator wipeoutAnimator;

   public int numKills;
   public GameObject crownGlow;

   public float upForce;

   // Update is called once per frame
   void Update()
   {
      if (isWipeout && !ended)
      {
         Wipeout();
      }

   }

   public void startWipeout()
   {
      if (numKills >= 3)
      {
         wipeoutAnimator.Play("Wipeout");
         this.isWipeout = true;
         numKills = 0;
         crownGlow.SetActive(false);
      }

   }

   public void Wipeout()
   {
      current = Vector3.Lerp(startWPos, endWPos, lTime);
      transform.localPosition = current;
      lTime += Time.deltaTime;

      if (transform.localPosition.y >= endWPos.y)
      {
         // reset wipeout status
         transform.localPosition = startWPos;
         ended = true;
         //Debug.Log("Reset Wipeout");
      }

   }

   public void IncrementKills()
   {
      numKills++;

      if (numKills >= 3)
         crownGlow.SetActive(true);
   }

   public bool isEnded() { return ended; }

   public void reset()
   {
      isWipeout = false;
      lTime = 0;
      ended = false;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      string tag = collision.tag;

      if (isWipeout)
      {
         if (tag == "Garbage Bag" ||
             tag == "Waste Barrell" ||
             tag == "Mines" ||
             tag == "Torpedo" ||
             tag == "CementLegGuy")
         {
            StartCoroutine(DelayedAddForce(0.1f, collision));
         }
      }
   }

   IEnumerator DelayedAddForce(float delay, Collider2D collision)
   {
      yield return new WaitForSeconds(delay);
      Rigidbody2D rb2d = collision.transform.GetComponent<Rigidbody2D>();
      rb2d.AddForce(new Vector2(0f, upForce));
   }

}
