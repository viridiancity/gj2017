using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
   public GameObject smallTrashPrefab;
   public int amountToSpawn;
   public float explosionForce;

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      string tag = collision.transform.tag;
      if (tag == "Garbage Bag" ||
          tag == "Waste Barrell" ||
          tag == "Mines" ||
          tag == "Torpedo" ||
          tag == "CementLegGuy")
      {
         for (int i = 0; i < amountToSpawn; i++)
         {
            GameObject smallTrash = Instantiate(smallTrashPrefab, transform.position, Quaternion.identity);

            float xForce = Random.Range(-5f, 5f);
            float yForce = Random.Range(0f, 5f);

            smallTrash.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xForce, yForce) * explosionForce);
         }

         Destroy(gameObject);

      }
   }
}
