﻿using UnityEngine;
using System.Collections;

public class DropProjectile : MonoBehaviour
{
   public GameObject projectilePrefab;

   public float minAttackDelay;
   public float maxAttackDelay;

   // Use this for initialization
   void Start()
   {
      StartCoroutine(DelayThenAttack());
   }

   // Update is called once per frame
   void Update()
   {

   }

   IEnumerator DelayThenAttack()
   {
      float delay = Random.Range(minAttackDelay, maxAttackDelay);
      yield return new WaitForSeconds(delay);

      GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
      projectile.GetComponent<Rigidbody2D>().AddTorque(10f);
      StartCoroutine(DelayThenAttack());

   }

}
