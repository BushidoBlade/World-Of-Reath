using UnityEngine;
using System.Collections;

public class GameTypesMenu_Hard : MonoBehaviour {

	sceneFadeInOut end;
	public bool sceneEnding = false;
	private GameObject music;

	void Awake () {
		end = GameObject.FindWithTag ("sceneFader").GetComponent<sceneFadeInOut> ();
		music = GameObject.FindWithTag ("MenuMusic");
	}

	void OnMouseDown () {
		sceneEnding = true;
	}
	
	void Update(){

		if (sceneEnding) {
			if (music.audio.volume > 0)
				music.audio.volume -= Time.deltaTime;
			end.EndScene ("Town");
		}
	}
}