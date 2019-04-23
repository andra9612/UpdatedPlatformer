using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretScript : MonoBehaviour {

	public Transform fatherSecret;

	RecordsScript record;

	// Use this for initialization
	void Start () {

		record = RecordsScript.getRecord ();
		record.SumOfMaxSecrets (fatherSecret.childCount);
		record.MaxCountSecret(fatherSecret.childCount);
		record.CountSecret(0);
	}
		
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			record.IncTotalSecrets (true);
			record.CountSecret(1);
		}

	}
}
