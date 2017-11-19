using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private BlockSpawner bs;
	bool first;

	void Start () {
		bs = FindObjectOfType<BlockSpawner> ();
		first = gameObject.transform.position.y < 15;
	}

	void Update () {
		GameController.moveDown (transform);

		if (transform.position.y < GameController.deathY) {
			if (first) {
				bs.spawnBlock ();
			}
			Destroy (gameObject);  
		}
	}
}
