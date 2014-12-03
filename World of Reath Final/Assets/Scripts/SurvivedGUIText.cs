using UnityEngine;
using System.Collections;

public class SurvivedGUIText : MonoBehaviour {
	private int minutesSurvived = 0;
	GameTimer timer;
	GameObject timerObj;

	// Use this for initialization
	void Awake(){
		timerObj = GameObject.FindWithTag ("GameTimer");
		timer = GameObject.FindWithTag ("GameTimer").GetComponent<GameTimer> ();
		minutesSurvived = timer.gameTimer / (int)60;
		Destroy (timerObj);
	}

	// Update is called once per frame
	void Update () {
		if(minutesSurvived == 1)
			guiText.text = "You survived for: " + minutesSurvived + " minute";
		else
			guiText.text = "You survived for: " + minutesSurvived + " minutes";
	}
}
