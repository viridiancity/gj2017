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

    private List<GameObject> subList;
    private int maxSubs;
    private float tLastSpawn;

    public float minSpawnTime;
    public float maxSpawnTime;

    private float nextminSpawn;
    private float nextmaxSpawn;
    //public GameObject shipfact;

    private bool active;



    // Use this for initialization
    void Start () {
        active = false;
        tLastSpawn = Time.time;
        nextminSpawn = tLastSpawn + minSpawnTime;
        nextmaxSpawn = tLastSpawn + maxSpawnTime;
        // debug spawn
        active = true;
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {

        // check if any subs are inactive
        //foreach ( GameObject s in subList ){
        //    if ( )
        //    {
        //        s
        //    }
        //}

        if (active)
        {
            float activesubs = 1;
            float maxactivesubs = 3;
            if (activesubs > maxactivesubs)
            {

            } else {

                if (tLastSpawn > nextminSpawn && tLastSpawn < nextmaxSpawn)
                {
                    // random chance of spawning
                    if (tLastSpawn % Random.Range(1, 550313) % 5 == 3)
                    {
                        SpawnAndResetSpawnTimers();
                    }
                } else if (tLastSpawn > nextmaxSpawn)
                {
                    // spawn and reset tLastSpawn
                    SpawnAndResetSpawnTimers();

                }
                tLastSpawn += Time.deltaTime;
            }
        }
        
    }

    public void activate()
    {
        active = true;
        SpawnAndResetSpawnTimers();
    }

    void SpawnAndResetSpawnTimers()
    {
        // can add remaining time to min time
        tLastSpawn = Time.time;

        nextminSpawn = tLastSpawn + minSpawnTime;
        nextmaxSpawn = tLastSpawn + maxSpawnTime;

        Spawn();
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
