using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFactory : MonoBehaviour {

    protected static ShipFactory instance;
    public GameObject sub;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () { }

    //public static SubmarineSpawnScript CreateSub(string name, int health, string weapon, bool forceUser)
    //{
        //var enemy = Object.Instantiate(instance.sub, Vector3.zero, Quaternion.identity).GetComponent<Submarin>();
        //enemy.Initialize(name, health, weapon, forceUser);
        //return enemy;
    //}

}