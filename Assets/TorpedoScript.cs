using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {

    private enum STATE { SPAWN, ASCENDING, PEAK, DESCENDING }

    private STATE state;
    public float ythresh; // height for torpedo to ascend to
    public Vector3 centerofmass;
    public Rigidbody2D rb2d;
    public CapsuleCollider2D cc2d;
    // Use this for initialization
    void Start () {

        state = STATE.SPAWN;
        fire();
        state = STATE.ASCENDING;
        cc2d.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case STATE.ASCENDING:
                // fire to peak target
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 400));

                if ( transform.localPosition.y > ythresh)
                {
                    state = STATE.PEAK;
                    //centerofmass = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
                    //rb2d.centerOfMass = centerofmass;
                }

                break;
            case STATE.PEAK:
                cc2d.enabled = true;
                break;
            case STATE.DESCENDING:

                break;

        }
    }

    public void fire()
    {

    }

    public void init(Vector3 start)
    {
        transform.position = start;
        ythresh = start.y + 5;
    }


}

internal class RigidBody2D
{
}