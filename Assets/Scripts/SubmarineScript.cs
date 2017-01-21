using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineScript : MonoBehaviour {

    public Vector3 startpos;
    public Vector3 target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        // move to target, fire, move off screen


	}

    public void init(Vector3 startpos, Vector3 target, string dir)
    {
        transform.localPosition = startpos;

        if ( dir == "LEFT" )
        {
            // multiply rotation as appropriate to flip sprite direction
        } else
        {
            // right

        }
    }

}
