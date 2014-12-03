using UnityEngine;
using System.Collections;

public class GameOver_TryAgain : MonoBehaviour {
	sceneFadeInOut end;
	private bool sceneEnding = false;

	void Start () {
		end = GameObject.FindWithTag ("sceneFader").GetComponent<sceneFadeInOut> ();
	}

	void OnMouseDown () {
		sceneEnding = true;
	}
	void update(){
		if (sceneEnding)
			end.EndScene("Town");
	}
}
