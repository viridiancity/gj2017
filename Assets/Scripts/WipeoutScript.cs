using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeoutScript : MonoBehaviour {

    private Vector3 current;
    public Vector3 endWPos   = new Vector3(1, 6.5f, 1);
    public Vector3 startWPos = new Vector3(1, -11f, 1);
    private float lTime = 0;
    public bool isWipeout = false;
    public bool started   = false;
    public bool ended     = false;

   public float upForce;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ( isWipeout && !ended)
        {
            Wipeout();
        }

	}

    public void startWipeout()
    {
        this.isWipeout = true;
    }

    public void Wipeout()
    {
        //Debug.Log("Wipeout!!_!!!!!?!");
        
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
