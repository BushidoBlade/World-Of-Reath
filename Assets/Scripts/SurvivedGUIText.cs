using UnityEngine;
using System.Collections;

public class SurvivedGUIText : MonoBehaviour {
	public int timeSurvived = 0;
	GameTimer timer;
	// Use this for initialization
	void Awake(){
		timer = GameObject.FindWithTag ("GameTimer").GetComponent<GameTimer> ();
	}
	void Start () {
		timeSurvived = timer.gameTimer / (int)60;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "You survived for: " + timeSurvived + " minutes";
	}
}
