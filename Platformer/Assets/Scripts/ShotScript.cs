using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

	Rigidbody2D cannon;

	public static float shotForse = 700f;

	public static float coldown = 0f;

	void Start () {
		cannon = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){

		if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponScript.isLifted == true ) {
			cannon.AddForce (new Vector2 (shotForse, 0f));
			WeaponScript.isLifted = false;
			WeaponScript.shot.parent = null;
			NinjaScript.jump = 700f;
			Destroy (gameObject, 5f);
			coldown = 5f;
		}

		coldown -= Time.deltaTime;
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag != "Player" && col.transform.tag != "Weapon"  && !WeaponScript.shot.IsChildOf(GameObject.Find("Weapon").transform)  )  {
			Destroy (gameObject, 1);
			coldown = 0f;
		}

	}
}
