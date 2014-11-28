using UnityEngine;
using System.Collections;

public class GameOver_Exit : MonoBehaviour {
	sceneFadeInOut end;
	public bool sceneEnding = false;

	void Start () {
		end = GameObject.FindWithTag ("sceneFader").GetComponent<sceneFadeInOut> ();
	}

	void OnMouseDown () {
		sceneEnding = true;
	}
	void update(){
		if (sceneEnding)
			end.EndScene("StartMenu");
	}
}
