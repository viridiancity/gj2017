using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSpawnScript : MonoBehaviour {

    public int layer; // layer 1, 2, 3

    public string side;
    public GameObject sub;
    public GameObject SubmarineTarget;
    //public GameObject shipfact;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn() // does not necessarily need to differentiate
    {
        GameObject o = Instantiate(sub);
        if ( side == "Right")
        {
            o.GetComponent<SubmarineScript>().init(transform.localPosition, SubmarineTarget.transform.localPosition, "LEFT");
            
        } else if ( side == "Left")
        {
            
            o.GetComponent<SubmarineScript>().init(transform.localPosition, SubmarineTarget.transform.localPosition, "RIGHT");
        }
        o.transform.localPosition = transform.localPosition;
        //GameObject s = shipfact.GetComponent<ShipFactory>().getSub(SubmarineTarget);

        //GameObject s = Instantiate(sub, transform.localPositionm, Quaternion.identity);
        //o.initia enemy.Initialize("Darth Vader", 9000, "lightsaber", true);

        //Instantiate( sub )

    }

}
