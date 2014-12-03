using UnityEngine;
using System.Collections;

public class Tutorial_Manager : MonoBehaviour {
	
	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}
	
	void Update(){
		if (Input.GetKey(KeyCode.Escape)){
			Application.LoadLevel("StartMenu");
		}
	}
}