using UnityEngine;
using System.Collections;

public class SurvivedGUIText : MonoBehaviour {
	public int minutesSurvived = 0;
	GameTimer timer;
	// Use this for initialization
	void Awake(){
		timer = GameObject.FindWithTag ("GameTimer").GetComponent<GameTimer> ();
	}
	void Start () {
		minutesSurvived = timer.gameTimer / (int)60;
	}
	
	// Update is called once per frame
	void Update () {
		if(minutesSurvived <= 1)
			guiText.text = "You survived for: " + minutesSurvived + " minute";
		else
			guiText.text = "You survived for: " + minutesSurvived + " minutes";
	}
}
