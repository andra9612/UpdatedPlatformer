using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	private static HealthScript health;

	public static int hp = 3;

	 public void Damage (){
		hp -= 1;
		if (hp == 0) {
			Application.LoadLevel (1);
			hp = 3;
		}

	}

	public void incHealth(){
		hp++;
	}

	public  int Hp(){
		return hp;
	}

	public static HealthScript getHealth (){

		if (health == null)
			health = new HealthScript ();
		return health;
	}
				
}
