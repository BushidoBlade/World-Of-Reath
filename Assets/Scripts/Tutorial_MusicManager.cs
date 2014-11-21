using UnityEngine;
using System.Collections;

public class Tutroial_GameController : MonoBehaviour {
	
	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}
}