using UnityEngine;
using System.Collections;

public class NightFade : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	private Color night;
	public bool isNight;
	public float alpha;
	GameTimer timer;
	
	void Awake (){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
		timer = GameObject.FindWithTag("GameTimer").GetComponent<GameTimer>();
		night = new Color(0.0f, 0.0f, 0.2f, 0.15f);
	}
	
	void Update(){
		alpha = guiTexture.color.a;
		if ((timer.gameTimer == 10) && !isNight) {
			StartNight();
		}
		else if ((timer.gameTimer == 25) && isNight) {
			EndNight();
		}
	}
	
	void StartNight (){
		guiTexture.color = Color.Lerp(guiTexture.color, night, fadeSpeed * Time.deltaTime);

		if (guiTexture.color.a > 0.09f) {
			guiTexture.color = night;
			isNight = true;
		}
	}

	void EndNight (){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);

		if (guiTexture.color.a < 0.04f) {
			guiTexture.color = Color.clear;
			isNight = false;
		}
	}

}
