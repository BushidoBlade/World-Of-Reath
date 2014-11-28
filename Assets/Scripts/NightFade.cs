using UnityEngine;
using System.Collections;

public class NightFade : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	private Color night;
	public bool isNight = false;
	public float alpha;
	GameTimer timer;
	
	void Awake (){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
		timer = GameObject.FindWithTag("GameTimer").GetComponent<GameTimer>();
		night = new Color(0.0f, 0.0f, 0.2f, 0.15f);
		if (timer.sceneTrans) {
			if (timer.nightTime) {
				timer.sceneTrans = false;
				isNight = true;
				guiTexture.color = night;
			}
			else if (!timer.nightTime){
				timer.sceneTrans = false;
				isNight = false;
				guiTexture.color = Color.clear;
			}
		}

	}

	void Update(){
		alpha = guiTexture.color.a;
		if (!isNight && timer.nightTime) {
			StartNight ();
		} else if(isNight && !timer.nightTime) {
			EndNight ();
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