using UnityEngine;
using System.Collections;

public class Hard_GameController : MonoBehaviour {

	public int gameTimer;
	public bool isNight;
	sceneFadeInOut end;
	
	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
		InvokeRepeating("incrTimer", 0, 1.0f);
	}

	void Start(){
		end = GameObject.FindWithTag("sceneFader").GetComponent<sceneFadeInOut>();
		isNight = false;
		gameTimer = 0;
	}

	void incrTimer(){
		gameTimer++;
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			end.EndScene ();
		}
	}
}
