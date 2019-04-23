using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour {


	HealthScript heath  = HealthScript.getHealth();

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			heath.incHealth ();
		}
	}
}
