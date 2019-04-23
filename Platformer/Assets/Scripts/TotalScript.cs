using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScript : MonoBehaviour {

	RecordsScript record =  RecordsScript.getRecord();

	void OnGUI(){

		GUI.TextArea (new  Rect(Screen.width/2-100, Screen.height/2 - 100, 200, 100), string.Format(@"Вітаю, ви завершили гру
за гру ви зібрали 		{0} монет із {1} та {2} секрнетів із  {3} ", record.IncTotalCoins(false), record.SumOfMaxCoins(-1), record.IncTotalSecrets(false), record.SumOfMaxSecrets(-1)));

		if (GUI.Button (new Rect (new  Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 50)), "Назад"))
			Application.LoadLevel (0);
	}
}
