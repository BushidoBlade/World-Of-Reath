using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
	sceneFadeInOut end;
	PlayerController_Physics player;
	PlantEnemyController enemy;
	public bool sceneEnding = false;
	public string level;
	GameTimer timer;
	
	void Awake() {
		end = GameObject.FindWithTag("sceneFader").GetComponent<sceneFadeInOut>();
		timer = GameObject.FindWithTag("GameTimer").GetComponent<GameTimer>();
	}

	void Start(){
	}
	
	void Update(){
		if (sceneEnding) {
			timer.sceneTrans = true;
			end.EndScene (level);
		}
	}
}
