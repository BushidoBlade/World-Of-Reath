using UnityEngine;
using System.Collections;

public class Hard_GameController : MonoBehaviour {

	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}
	void Update(){
		if (Input.GetKey(KeyCode.Escape)){
			Application.LoadLevel("StartMenu");
		}
	}
}
