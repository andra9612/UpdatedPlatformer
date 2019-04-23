using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public int window;
	int position = 20;

	// Use this for initialization
	void Start () {
		window = 1;
	}

	void OnGUI(){
		GUI.BeginGroup (new Rect(Screen.width/2-100, Screen.height/2 - 100, 200,400));
		if (window == 1) {
			if(GUI.Button(new Rect(0, 10, 200, 50), "Грати"))
				window = 2;
			if (GUI.Button(new Rect(0, 60, 200, 50), "Інформація"))
				window = 3;
			if (GUI.Button (new Rect (0, 110, 200, 50), "Вихід"))
				window = 4;
		}

		if (window == 2) {

			GUI.Label (new Rect(60,0,200,50), "Оберіть рівень");
			for (int i = 1; i < Application.levelCount-1; i++) {
				if (GUI.Button (new Rect (0, 50 * i, 200, 50), "Рівень" + (i).ToString ()))
					Application.LoadLevel (i);
			}
			if (GUI.Button (new Rect (0, 300, 200, 50), "Назад"))
				window = 1;				
		}

		if (window == 3) {
				GUI.TextArea ( new Rect(0,0,200,50), "Переміщення:\tA  та  D\nСтрибок:\t\tSpace\n Постріл:\t\tLeft Mouse Button");
			if (GUI.Button (new Rect (0, 50, 200, 50), "Назад"))
				window = 1;		
		}
		if (window == 4) {
			Application.Quit ();
		}
		GUI.EndGroup ();
	}
}
