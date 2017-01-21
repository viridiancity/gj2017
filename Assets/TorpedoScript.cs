﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {

    private enum STATE { SPAWN, ASCENDING, PEAK, DESCENDING }

    private STATE state;

	// Use this for initialization
	void Start () {
        state = STATE.SPAWN;
            fire();
        state = STATE.ASCENDING;
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case STATE.ASCENDING:
                // fire to peak target
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 160));
                break;
            case STATE.PEAK:

                break;
            case STATE.DESCENDING:

                break;

        }
    }

    public void fire()
    {

    }

}
