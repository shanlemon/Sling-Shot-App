using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {

	public bool isWall = false;

    void OnTriggerEnter2D(Collider2D col) {
		col.gameObject.GetComponent<PlayerController> ().stick (gameObject);
		gameObject.GetComponent<SpriteRenderer> ().color = PlayerController.green;
		if(!isWall)
			col.gameObject.GetComponent<PlayerController> ().setPosition (gameObject);
	}
}