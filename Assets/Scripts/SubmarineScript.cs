using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineScript : MonoBehaviour {

    public Vector3 startpos;
    public Vector3 targetpos;
    private enum SUBSTATE { SPAWNED, TOTARGET, REACHEDTARGET, FIRED, LAUNCHED, FROMTARGET, OFFSCREEN};
    private      SUBSTATE state;
    public GameObject torpedo;
    private Vector3 n;
    private float lTime;
    public float waitTime;
    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () {

        switch ( state)
        {
            case SUBSTATE.SPAWNED:
                // move to target, fire, move off screen
                lTime = 0;
                break;

            case SUBSTATE.TOTARGET:
                n = Vector3.Lerp(startpos, targetpos, lTime/3);
                lTime += Time.deltaTime;
                transform.localPosition = n;
                if (Vector3.Distance ( transform.localPosition, targetpos ) < 0.005f )
                {
                    lTime = 0;
                    state = SUBSTATE.REACHEDTARGET;
                }

                break;

            case SUBSTATE.REACHEDTARGET:
                // fire the sail off
                if ( lTime < waitTime)
                {
                    lTime += Time.deltaTime;
                } else
                {
                    fire();
                    lTime = 0;
                    state = SUBSTATE.LAUNCHED;
                }
                
                break;
            case SUBSTATE.LAUNCHED:
                // wait a little until disappearing
                if (lTime < waitTime)
                {
                    lTime += Time.deltaTime;
                }
                else
                {
                    lTime = 0;
                    state = SUBSTATE.FROMTARGET;
                }

                break;
            case SUBSTATE.FROMTARGET:
                n = Vector3.Lerp(targetpos, startpos, lTime);
                transform.localPosition = n;
                lTime += Time.deltaTime;
                if (Vector3.Distance(transform.localPosition, startpos) < 0.005f)
                {
                    state = SUBSTATE.OFFSCREEN;
                }
                break;

            case SUBSTATE.OFFSCREEN:
                // destroy
                break;
        }

	}

    private void fire()
    {
        Debug.Log("Fire !");
        Vector3 sp = transform.localPosition;
        torpedo.GetComponent<TorpedoScript>().init(transform.position);
        Instantiate(torpedo, transform);
    }

    public void init(Vector3 startpos, Vector3 target, string dir)
    {
        transform.localPosition = startpos;
        this.startpos = startpos;
        targetpos = target;
        state = SUBSTATE.TOTARGET; //substate.spawned, then orient ?
        if ( dir == "LEFT" )
        {
            // flip sprite so submarine travels in the right direction
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            // multiply rotation as appropriate to flip sprite direction

        } else
        {
            // right

        }
    }

}
