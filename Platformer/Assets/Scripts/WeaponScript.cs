using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public static  bool isLifted =  false;

	public  Transform player;

	public Transform weapon;

	Rigidbody2D  cannon;

	public static Transform shot;

	void OnCollisionEnter2D(Collision2D col){

		if (col.transform.tag == "Player" && isLifted == false && ShotScript.coldown <=0) {

			shot = 	Instantiate (weapon, player.position, Quaternion.identity);
			shot.transform.parent = player;
			NinjaScript.jump = 500f;
			isLifted = true;
		}
	}


	void Update(){

		if (isLifted)
			shot.position = player.position;
	}
}
