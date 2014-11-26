using UnityEngine;
using System.Collections;

public class NightFade : MonoBehaviour {

	
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public Color night;
	public bool isNight;
	public float nightTimerSec = 0.0f;
	Hard_GameController timer;
	
	void Awake (){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
		timer = GameObject.FindWithTag("MainCamera").GetComponent<Hard_GameController>();
		night = new Color(0.0f, 0.0f, 0.2f, 0.15f);
	}
	
	void Update(){
		if ((timer.gameTimer == 20) && !isNight) {
			StartNight();
		}
		else if ((timer.gameTimer == 40) && isNight) {
			EndNight();
		}
	}
	
	
	void FadeToClear (){
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, Time.deltaTime);
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, Time.deltaTime);
	}
	
	
	void FadeToBlue (){
		guiTexture.color = Color.Lerp(guiTexture.color, night, Time.deltaTime);
	}
	

	void StartNight (){
		FadeToBlue();

		if (guiTexture.color.a > 0.09f) {
			guiTexture.color = night;
			isNight = true;
			timer.isNight = true;
		}
	}

	void EndNight (){
		FadeToClear ();

		if (guiTexture.color.a < 0.03f) {
			guiTexture.color = Color.clear;
			isNight = false;
			timer.isNight = false;
		}
	}

}
