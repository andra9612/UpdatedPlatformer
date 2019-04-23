using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {


	public float speed  = 5f;

	public float startX, startY;

	public float maxDistans;

	public float deltaX, deltaY;

	public bool moveToRight = true;

	public Vector3 direction;




	void Start(){
		
		startX = transform.position.x;
		startY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (direction * speed * Time.deltaTime);

		deltaX  = transform.position.x - startX;
		deltaY = transform.position.y - startY;

		if ((deltaX > maxDistans || deltaY > maxDistans) && moveToRight) {
			direction.x *= -1;
			direction.y *= -1;
			moveToRight = !moveToRight;
		} else if ((deltaX < -maxDistans || deltaY < -maxDistans ) && moveToRight == false) {
			direction.x *= -1;
			direction.y *= -1;
			moveToRight = !moveToRight;
		}
	}
		
}
