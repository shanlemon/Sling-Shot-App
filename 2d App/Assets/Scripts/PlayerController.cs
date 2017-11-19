using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static Color red;
	public static Color green;

	public float speedMultiplier;
	public float minDistance, maxDistance;
    
	bool isStuck = false;
    bool showMarker = false;

	private GameObject stuckTo;

	private Rigidbody2D rb;
	private LineRenderer lr;

	void Start() {
		red = new Color (0.882f, 0.337f, 0.337f, 1f);
		green = GetComponent<SpriteRenderer> ().color;

		rb = GetComponent<Rigidbody2D> ();
		lr = GetComponent<LineRenderer> ();
		//unstick ();
	}


    void Update() {
        if (GameController.isRunning) {
            

			if (isStuck) {
				handleShooting();
				handleLine();

				if (GameController.hasStarted) {
					GameController.moveDown (transform);
				}
            } else {
				resetLine ();
            }
        }
	}

	Vector2 m1 = new Vector2(0, 0);
	Vector2 m2 = new Vector2(0, 0);

    void handleShooting() {
		if (Input.GetMouseButtonDown (0)) {
			m1 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			showMarker = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			m2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			launch (m1, m2);
			showMarker = false;
		}
	}

	void handleLine() {
		if (showMarker) {
			lr.positionCount = 2;
			lr.SetPosition (0, m1);
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mosPos.z = 0;
            float dist = Vector2.Distance(m1, mosPos);
            float angle = Mathf.Atan2(m1.y - mosPos.y, m1.x - mosPos.x);
            
            if (dist > maxDistance) {
                mosPos = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward) * Vector3.right;
                Ray rayToTest = new Ray(m1, -mosPos);
                mosPos = rayToTest.GetPoint(maxDistance);
                
            }
            lr.SetPosition(1, mosPos);
		} else {
			resetLine ();
		}
	}

	void resetLine() {
		lr.positionCount = 0;
	}

	public void stick(GameObject obj) {
		isStuck = true;
		rb.gravityScale = 0;
		rb.velocity = new Vector3 (0, 0, 0);
		stuckTo = obj;
	}

	public void setPosition(GameObject obj){
		transform.position = obj.transform.position;
	}

    public void unstick() {
		GameController.hasStarted = true;
		isStuck = false;
		rb.gravityScale = 1;

		stuckTo.GetComponent<SpriteRenderer> ().color = red;
	}

    void launch(Vector2 mousePos1, Vector2 mousePos2) {
		float angle = Mathf.Atan2 (mousePos1.y - mousePos2.y, mousePos1.x - mousePos2.x) * Mathf.Rad2Deg;
		Vector2 force = Quaternion.AngleAxis (angle, Vector3.forward) * Vector3.right;

		if (!Physics2D.Raycast (transform.position, force, 1)) {
			unstick ();
			float distance = Vector2.Distance (mousePos1, mousePos2);
			if (distance > maxDistance)
				distance = maxDistance;
			else if (distance < minDistance)
				distance = minDistance;

			rb.AddForce (force * distance * speedMultiplier);
		}
	}
}