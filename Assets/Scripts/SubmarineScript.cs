using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineScript : MonoBehaviour {

    public Vector3 startpos;
    public Vector3 targetpos;
    private enum SUBSTATE { SPAWNED, TOTARGET, REACHEDTARGET, FROMTARGET, OFFSCREEN};
    private      SUBSTATE state;
    public GameObject torpedo;
    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () {

        switch ( state)
        {
            case SUBSTATE.SPAWNED:
                // move to target, fire, move off screen

                break;

            case SUBSTATE.TOTARGET:
                Vector3 n = Vector3.Lerp(startpos, targetpos, 5f);
                transform.localPosition = n;
                if (Vector3.Distance ( transform.localPosition, targetpos ) < 0.005f )
                {
                    state = SUBSTATE.REACHEDTARGET;
                }
                break;

            case SUBSTATE.REACHEDTARGET:
                // fire the sail off
                fire();
                state = SUBSTATE.FROMTARGET;
                break;

            case SUBSTATE.FROMTARGET:
                break;

            case SUBSTATE.OFFSCREEN:
                break;
        }

	}

    private void fire()
    {
        Debug.Log("Fire !");
    }

    public void init(Vector3 startpos, Vector3 target, string dir)
    {
        transform.localPosition = startpos;
        this.startpos = startpos;
        targetpos = target;
        state = SUBSTATE.TOTARGET; //substate.spawned, then orient ?
        if ( dir == "LEFT" )
        {
            // multiply rotation as appropriate to flip sprite direction

        } else
        {
            // right

        }
    }

}
