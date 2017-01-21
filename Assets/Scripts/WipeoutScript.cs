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
        current = Vector3.Lerp(startWPos, endWPos, lTime);
        transform.localPosition = current;
        lTime += Time.deltaTime;

        if (transform.localPosition.y >= endWPos.y)
        {
            // reset wipeout status
            transform.localPosition = startWPos;
            ended = true;
            Debug.Log("Reset Wipeout");
        }
    }

    public bool isEnded() { return ended; }

    public void reset()
    {
      Debug.Log("Reset function here");
        this.isWipeout = false;
        lTime = 0;
        ended = false;
    }
}
