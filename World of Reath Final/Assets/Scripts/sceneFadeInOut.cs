using UnityEngine;
using System.Collections;

public class sceneFadeInOut : MonoBehaviour {
	
	public float fadeSpeed = 2.0f;
	private bool sceneStarting;

	void Awake (){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		sceneStarting = true;
	}
	
	
	void Update (){
		if (sceneStarting)
			StartScene();
	}
	
	
	void FadeToClear (){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack (){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene (){
		FadeToClear();

		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.01f){
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene (string level){
		guiTexture.enabled = true;

		FadeToBlack ();

		// If the screen is almost black...
		if (guiTexture.color.a >= 0.90f) {
			Application.LoadLevel(level);
		}
	}
}