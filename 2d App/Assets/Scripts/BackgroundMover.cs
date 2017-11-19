using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameController.moveDown(transform);
        if(transform.position.y < -22.56) {
            transform.position = new Vector3(0, -.24f, 0);
        }
	}
}
