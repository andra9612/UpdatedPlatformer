using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsScript : MonoBehaviour {

	HealthScript health = HealthScript.getHealth();
	
	public static  int maxCountCoint;

	public static  int countCoins; 

	public static   int countSecret;

	public  static  int maxCountSecret;

	public static int totalCoins;

	public static int totalSecrets;

	public static int allCoins;

	public static int allsecrets;

	private static RecordsScript record;

	public void MaxCoins(int value){

		maxCountCoint =  value;
	}

	public int SumOfMaxCoins(int count){
		
		if(count > 0)
			allCoins += count;
		return allCoins;
	}

	public int SumOfMaxSecrets(int count){

		if(count > 0)
			allsecrets += count;

		return allsecrets;
	}

	public int IncTotalCoins(bool value){

		if(value)
			totalCoins++;

		return totalCoins;
	}

	public int  IncTotalSecrets(bool value){
		if(value)
			totalSecrets++;

		return totalSecrets;
	}

	public void CountCoins(int value){

		if (value == 0)
			countCoins = 0;
		else
			countCoins++;
	}

	public void CountSecret(int value){

		if (value == 0)
			countSecret = 0;
		else
			countSecret++;
	}

	public void MaxCountSecret(int value){

		maxCountSecret =  value;
	}
		

	void OnGUI(){
		
		GUI.Box (new Rect (10, 10, 100, 100),"Health: " + health.Hp() + "\n" +   "Coins:" + countCoins + "/" + maxCountCoint  + "\n" + "Secrets:" + countSecret + "/" + maxCountSecret);
	}

	public static RecordsScript getRecord(){

		if (record == null)
			record = new RecordsScript ();

		return record;
	}
}
