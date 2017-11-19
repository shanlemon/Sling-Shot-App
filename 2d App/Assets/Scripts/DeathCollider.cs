using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {

    private GameController gc;

    void Start() {
		gc = FindObjectOfType<GameController> ();
	}

    void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			col.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			col.GetComponent<Rigidbody2D> ().gravityScale = 0;
			gc.endGame ();
		}
	}
}
