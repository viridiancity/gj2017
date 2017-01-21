using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int health;

    
    public Vector3 endScale = new Vector3(1.25f, 1.25f, 1.25f);

    private Vector3 startScale = new Vector3(1, 1, 1);
    private Vector3 current = new Vector3(0, 0, 0);
    private bool charging = false;
    private float lTime = 0;
    private float scharge;

    public float chargeTime = 1f;
    // Update is called once per frame

    public GameObject wipeoutObj;
    public Vector3 endWPos   = new Vector3 (1, 6.5f, 1);
    public Vector3 startWPos = new Vector3(1, -11f, 1);
    private bool isWipeout = false;

    void Update()
    {
        if (isWipeout)
        {
            if ( wipeoutObj.GetComponent<WipeoutScript>().isWipeout == false)
            {
                WipeOut();
            } if ( wipeoutObj.GetComponent<WipeoutScript>().ended)
            {
                wipeoutObj.GetComponent<WipeoutScript>().ended = false;
                isWipeout = false;
            }

        } else if (charging)
        {

            current = Vector3.Lerp(startScale, endScale, lTime);
            transform.localScale = Vector3.Lerp(startScale, endScale, lTime);
            lTime += Time.deltaTime;

        }
        else
        {
            lTime = 0;
            charging = false;

            transform.localScale = new Vector3(1, 1, 1);
            startScale = new Vector3(1, 1, 1);
            /*if ( current.x > start.x && current.y > start.y )
            {
                start = new Vector3(1, 1, 1);
                transform.localScale = Vector3.Lerp(current, start, lTime);
                lTime += Time.deltaTime;
            } else
            {
                current = Vector3.zero;
                lTime = 0;
                start = new Vector3(1, 1, 1);
            }*/

        }

    }

    void OnMouseUp()
    {

        if (scharge + lTime >= scharge + chargeTime)
        {
            // fire epic
            //lTime = 0;
            isWipeout = true;
            //WipeOut();

        }

        lTime = 0;
        charging = false;

        transform.localScale = new Vector3(1, 1, 1);
        startScale = new Vector3(1, 1, 1);

    }

    void OnMouseDown()
    { // shouldn't be able to be called twice with one finger touch inputs without triggering OnMouseUp first .. hopefully
        if ( !charging && !isWipeout )
        {
            charging = true;
            lTime = 0;
            scharge = Time.time;
            transform.localScale = new Vector3(1, 1, 1);
            startScale = new Vector3(1, 1, 1);
        }

    }

    void OnMouseOver()
    { // mouse over not really triggered on touch controls

    }

    void WipeOut()
    { // fire in WaveManager, or spawn wipeout wave
        Debug.Log("Wipeout");

        wipeoutObj.GetComponent<WipeoutScript>().startWipeout();

        /*current = Vector3.Lerp(startWPos, endWPos, lTime);
        wipeoutObj.transform.localPosition = current;// Vector3.Lerp(new Vector3(0,0,0), endWPos, lTime);
        lTime += Time.deltaTime;
        if (wipeoutObj.GetComponent<Transform>().localPosition.y > endWPos.y)
        {
            // reset wipeout status
            wipeoutObj.GetComponent<Transform>().localPosition = startWPos;
            isWipeout = false;
            charging = false;
            lTime = 0;
            Debug.Log("Reset Wipeout");
        }*/

    }
    
}
