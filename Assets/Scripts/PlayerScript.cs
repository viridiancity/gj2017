using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
   public int health;

   // Update is called once per frame
   void Update()
   {

   }

   void OnMouseUp()
   {
      Debug.Log("Drag ended!");
   }
   
}
