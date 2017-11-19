using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerScroller : MonoBehaviour {

    public float speed;
	public float startX, endX;

	// Update is called once per frame
	void Update () {
       // if((transform.position.x < -22.91 && speed < 0) || (transform.position.x > -226.58 && speed > 0)) {
      //      speed *= -1;
       // }
		if (transform.position.x < endX  || transform.position.x > startX ) {
            speed *= -1;
        }
        transform.Translate(new Vector3(speed, 0, 0));
	}
}
