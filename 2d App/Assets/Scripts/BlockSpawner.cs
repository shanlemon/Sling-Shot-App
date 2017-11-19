using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public GameObject[] blocks;
	public GameObject border;
	public bool showBlocks;

	void Start () {
		spawnBlock ();
		if (showBlocks) {
			THISISTHESHOWBLOCKSMETHOD ();
		}
	}

    public void spawnBlock() {
		if (blocks.Length > 0) {
			Instantiate (blocks [Random.Range (0, blocks.Length)], new Vector2 (0, 10.06f), Quaternion.identity);
			//Instantiate (blocks [Random.Range (0, blocks.Length)], new Vector2 (0, 20f), Quaternion.identity);
			Instantiate (blocks [Random.Range (0, blocks.Length)], new Vector2 (0, 21f), Quaternion.identity);
		}
	}

	void THISISTHESHOWBLOCKSMETHOD() {
		for (int i = 0; i < blocks.Length; i++) {
			Instantiate (border, new Vector2 (-300 + i * 8 + 20, 30), Quaternion.identity);
			Instantiate (blocks [i], new Vector2 (-300 + i * 8 + 20, 30), Quaternion.identity);
		}
	}
}
