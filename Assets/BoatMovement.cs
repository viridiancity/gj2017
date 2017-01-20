using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour
{
   public Transform endPosition;
   public float speed;
   public int movingDirection = 1;

   private Vector3 startPosition;

   // Use this for initialization
   void Start()
   {
      startPosition = transform.position;
   }

   // Update is called once per frame
   void Update()
   {
      transform.Translate(Vector3.right * speed * Time.deltaTime);

      if (movingDirection == 1)
      {
         if (transform.position.x >= endPosition.position.x)
         {
            transform.Rotate(Vector3.up * 180f);
            movingDirection = 0;
         }
            
      }
      else if (movingDirection == 0)
      {
         if (transform.position.x <= startPosition.x)
         {
            transform.Rotate(Vector3.up * -180f);
            movingDirection = 1;
         }
      }
      
   }
}
