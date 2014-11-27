using UnityEngine;
using System.Collections;

public class sceneFadeInOut : MonoBehaviour {
	
	public float fadeSpeed = 1.0f;          // Speed that the screen fades to and from black.
	private bool sceneStarting;
	public float alpha;

	void Awake (){
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		sceneStarting = true;
	}
	
	
	void Update (){
		alpha = guiTexture.color.a;
		// If the scene is starting...
		if (sceneStarting)
			StartScene();
	}
	
	
	void FadeToClear (){
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack (){
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene (){
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.01f){
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}

	public void EndScene (string level){
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		//sceneEnding = true;
		
		// Start fading towards black.
		FadeToBlack ();

		// If the screen is almost black...
		if (guiTexture.color.a >= 0.90f) {
			Application.LoadLevel(level);
		}
	}
}