using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeoutScript : MonoBehaviour {

    private Vector3 current;
    public Vector3 endWPos = new Vector3(1, 6.5f, 1);
    public Vector3 startWPos = new Vector3(1, -11f, 1);
    private float lTime = 0;
    public bool isWipeout;
    public bool started = false;
    public bool ended = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ( isWipeout )
        {
            Wipeout();
        }

	}

    public void startWipeout()
    {
        isWipeout = true;
    }

    public void Wipeout()
    {
        Debug.Log("Wipeout!!_!!!!!?!");
        
        current = Vector3.Lerp(startWPos, endWPos, lTime);
        transform.localPosition = current;// Vector3.Lerp(new Vector3(0, 0, 0), endWPos, lTime);
        lTime += Time.deltaTime;

        if (transform.localPosition.y > endWPos.y)
        {
            // reset wipeout status
            transform.localPosition = startWPos;
            //isWipeout = false;
            //charging = false;
            lTime = 0;
            isWipeout = false;
            ended = false;
            Debug.Log("Reset Wipeout");
        }
    }

}
