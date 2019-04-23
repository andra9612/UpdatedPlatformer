using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	public Transform fatherCoin;

	int test;

	RecordsScript record = RecordsScript.getRecord ();

	void Awake () {
		test  = record.SumOfMaxCoins (fatherCoin.childCount);
		Debug.Log (test);
		record.MaxCoins(fatherCoin.childCount) ;
		record.CountCoins(0);
	}
		

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			record.IncTotalCoins (true);
			Destroy (gameObject);
			record.CountCoins(1);
		}
	}
}
