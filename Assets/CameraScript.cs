﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   Animator animator;

   // Use this for initialization
   void Start()
   {
      animator = GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void MoveToGame()
   {
      animator.Play("CameraMenuToGame");
   }

}
