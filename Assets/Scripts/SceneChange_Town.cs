using UnityEngine;
using System.Collections;

public class SceneChange_Town : MonoBehaviour {
	sceneFadeInOut end;
	PlayerController_Physics player;
	PlantEnemyController enemy;
	public bool sceneEnding = false;

	void Awake() {
		end = GameObject.FindWithTag("sceneFader").GetComponent<sceneFadeInOut>();
	}

	void Update(){
		if (sceneEnding)
			end.EndScene("Town");
	}
}
