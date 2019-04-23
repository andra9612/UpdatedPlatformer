using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public Transform pointA, pointB;

	public float speed;

	public Vector3 delta;

	public bool movingEnd = false;

	// Use this for initialization
	void Start () {
		delta = pointB.position - pointA.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > pointA.position.x && movingEnd == false) {
			transform.position = Vector3.MoveTowards (transform.position, pointA.position, delta.magnitude * Time.deltaTime * speed);
		} else if (transform.position.x < pointB.position.x) {
			transform.position = Vector3.MoveTowards (transform.position, pointB.position, delta.magnitude * Time.deltaTime * speed);
			movingEnd = true;
		} else if (transform.position.x == pointB.position.x)
			movingEnd = false;
	}
}
