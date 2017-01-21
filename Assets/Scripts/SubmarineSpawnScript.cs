using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSpawnScript : MonoBehaviour {

    public int layer; // layer 1, 2, 3

    public string side;
    public GameObject sub;
    public GameObject SubmarineTarget00;
    public GameObject SubmarineTarget01;
    public GameObject SubmarineTarget02;

    public float minSpawnTime;
    public float maxSpawnTime;
    //public GameObject shipfact;

    private bool active;

    private float tLastSpawn;

    // Use this for initialization
    void Start () {
        active = false;
        tLastSpawn = 0;

        // debug spawn
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {

        if ( active)
        {

            if ( tLastSpawn > minSpawnTime)
            {
                // random chance of spawning

            }

        }


    }

    void Spawn() // does not necessarily need to differentiate
    {
        GameObject o = Instantiate(sub);

        GameObject target;
        switch ( ( (int) Random.Range(15,30000) ) % 2 ){
            case 0:
                target = SubmarineTarget00;
                break;
            case 1:
                target = SubmarineTarget01;
                break;
            default:
                target = SubmarineTarget02;
                break;
        }
        
        if ( side == "Right")
        {
            Vector3 t = transform.localPosition;
            t.y = target.transform.position.y;
            o.GetComponent<SubmarineScript>().init(t, target.transform.position, "LEFT");
            
        } else if ( side == "Left")
        {
            Vector3 t = transform.localPosition;
            t.y = target.transform.position.y;
            o.GetComponent<SubmarineScript>().init(t, target.transform.position, "RIGHT");
        }

        //GameObject s = shipfact.GetComponent<ShipFactory>().getSub(SubmarineTarget);

        //GameObject s = Instantiate(sub, transform.localPositionm, Quaternion.identity);
        //o.initia enemy.Initialize("Darth Vader", 9000, "lightsaber", true);

        //Instantiate( sub )

    }

}
