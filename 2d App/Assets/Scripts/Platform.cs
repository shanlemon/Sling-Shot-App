using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void Update () {
		GameController.moveDown (transform);

		if (transform.position.y < GameController.deathY) {
			Destroy (gameObject);
		}
	}
}
