using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int health;

    float scale = 1.25f;
    Vector3 start = new Vector3(1, 1, 1);
    Vector3 end = new Vector3(1.25f, 1.25f, 1.25f);
    Vector3 current = new Vector3(0, 0, 0);
    private bool charging = false;
    float lTime = 0;
    float scharge;
    public float chargeTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if (charging)
        {
            current = Vector3.Lerp(start, end, lTime);
            transform.localScale = Vector3.Lerp(start, end, lTime);
            lTime += Time.deltaTime;

        }
        else
        {
            lTime = 0;
            charging = false;

            transform.localScale = new Vector3(1, 1, 1);
            start = new Vector3(1, 1, 1);
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
            WipeOut();
        }

        lTime = 0;
        charging = false;

        transform.localScale = new Vector3(1, 1, 1);
        start = new Vector3(1, 1, 1);

    }

    void OnMouseDown()
    { // shouldn't be able to be called twice with one finger touch inputs without triggering OnMouseUp first .. hopefully
        if ( !charging)
        {
            charging = true;
            lTime = 0;
            scharge = Time.time;
            transform.localScale = new Vector3(1, 1, 1);
            start = new Vector3(1, 1, 1);
        }

    }

    void OnMouseOver()
    { // mouse over not really triggered on touch controls

    }

    void WipeOut()
    { // fire in WaveManager, or spawn wipeout wave
        Debug.Log("Wipeout");
    }

    IEnumerator ScaleObject()
    {

        Debug.Log("scaling!");
        float scaleDuration = 5;                                //animation duration in seconds
        Vector3 actualScale = transform.localScale;             // scale of the object at the begining of the animation
        Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);     // scale of the object at the end of the animation

        for (float t = 0; t < 1; t += Time.deltaTime / scaleDuration)
        {
            transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            yield return null;
        }
    }
    
}
