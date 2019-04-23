using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float  posX, posY;

	public Rigidbody2D rig;

	HealthScript health  = HealthScript.getHealth();


	// Use this for initialization
	void Start () {

		rig = GetComponent<Rigidbody2D> ();
		//health = HealthScript.getHealth ();
		posX = rig.position.x;
		posY = rig.position.y;
		
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "dead") {
			health.Damage ();
			rig.position = new Vector2 (posX, posY);
		}
			
		if (col.gameObject.tag == "Heart") {

			health.incHealth ();
			Destroy (col.gameObject);
		}

		if (col.transform.tag == "MovingPlatform")
			transform.parent = col.transform;

		if (col.gameObject.tag == "LevelEnd")
			Application.LoadLevel (Application.loadedLevel + 1);
		
	}

	void OnCollisionExit2D(Collision2D col){

		if (col.transform.tag == "MovingPlatform")
			transform.parent = null;

	}
}
