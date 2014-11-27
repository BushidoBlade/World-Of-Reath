using UnityEngine;
using System.Collections;

public class Hard_GameController : MonoBehaviour {

	sceneFadeInOut end;
	public string level;
	public bool sceneEnding = false;


	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}

	void Start(){
		end = GameObject.FindWithTag("sceneFader").GetComponent<sceneFadeInOut>();
	}


	void Update(){
		if (Input.GetKey(KeyCode.Escape)) {
			sceneEnding = true;
			level = "StartMenu";
		}
		if (sceneEnding)
			end.EndScene(level);
	}
}