using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {

    private enum STATE { SPAWN, LAUNCH, ASCENDING, PEAK, DESCENDING }

    private STATE state;
    public float ythresh; // height for torpedo to ascend to
    public Vector3 centerofmass;
    public Rigidbody2D rb2d;
    public CapsuleCollider2D cc2d;
    public TorpedoTargetManager ttm;
    public Vector3 target;
    public Vector3 start;
    private float lTime;

    // Use this for initialization
    void Start () {

        state = STATE.SPAWN;
        fire();
        state = STATE.LAUNCH;
        cc2d.enabled = false;
        lTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case STATE.LAUNCH:
                
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
                
                cc2d.enabled = false;
                target = ttm.getTarget();
                start = transform.position;
                ythresh = target.y;
                state = STATE.ASCENDING;
                break;
            case STATE.ASCENDING:
                // fire to peak target
                // meander to target

                //if ( transform.position.y > ythresh)
                //{
                    //state = STATE.PEAK;
                    transform.position = Vector3.Lerp( start, target, lTime );
                    lTime += Time.deltaTime;
                    //centerofmass = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
                    //rb2d.centerOfMass = centerofmass;
                //}
                if ( Vector3.Distance(transform.position, target) < 0.05f)
                {
                    state = STATE.PEAK;
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