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
    public CircleCollider2D circc2d;
    public Vector3 target;
    public Vector3 start;
    public float steeravoidanceradius;
    private float lTime;

    // Use this for initialization
    void Start () {

        state = STATE.SPAWN;
        fire();
        state = STATE.LAUNCH;
        cc2d.enabled = false;
        lTime = 0;
        circc2d.enabled = false;
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
                    transform.position = Vector3.Slerp( start, target, lTime/3 );
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

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 800));
                state = STATE.DESCENDING;
                break;
            case STATE.DESCENDING:
                // steer away from and avoid barrels

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, steeravoidanceradius);
                int i = 0;
                float mindist = 9999;
                Collider mincol = null;
                foreach ( Collider c in hitColliders ) {
                    float dist = Vector3.Distance(c.transform.position, transform.position);
                    if ( dist < mindist && c.GetComponent<DropProjectile>() != null )
                    {
                        mindist = dist;
                        mincol = c;
                    }
                }
                if ( mincol != null)
                {
                    Debug.Log("projectile nearby !");
                    // avoid !
                }
                
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