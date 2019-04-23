using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaScript : MonoBehaviour {

	public float speed = 10f;

	public float radiusCheck = 1f;
	public  bool grounded = false;
	public Transform groundCheck;
	public LayerMask layer;

	public static float  jump = 700f;

	private bool isRight = true;

	private PlayerScript pl = new PlayerScript();

	public bool isWall = false;

	// Use this for initialization
	void Start () {
		//pl = gameObject.GetComponent<PlayerScript> ();
		pl.rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, radiusCheck, layer);

		float movement;
		movement = Input.GetAxis("Horizontal");

		pl.rig.velocity = new Vector2 (movement * speed, pl.rig.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
			pl.rig.AddForce( new Vector2(0, jump));


		if (movement > 0 && !isRight)
			Flip ();
		else if(movement < 0 && isRight)
			Flip();
		
	}


	void Flip(){
		ShotScript.shotForse *= -1;
		isRight = !isRight;
		Vector3 side = transform.localScale;
		side.x *= -1;
		transform.localScale = side;

	}

	void OnCollisionEnter2D(Collision2D col ){

		if (col.gameObject.tag == "wall")
			grounded = true;

	}
}
