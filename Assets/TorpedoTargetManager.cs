using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoTargetManager : MonoBehaviour {

    //public List<GameObject> tlist;
    public GameObject[] targets;// t00;
    /*public GameObject t01;
    public GameObject t02;
    public GameObject t03;
    public GameObject t04;
    public GameObject t05;*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 getTarget()
    {
        //Vector3 pos;
        /*switch ( Mathf.FloorToInt(Random.Range(0, 5)))
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            //case 5:
            default:
                break;
        }*/
        return targets[ Mathf.FloorToInt(Random.Range(0, 6)) ].transform.position;
    }

}
