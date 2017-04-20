using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //same as "this.transform"
        //(0,0,Space.Self) // vs Space.World
        transform.Rotate(0, speed, 0);
	}
}
