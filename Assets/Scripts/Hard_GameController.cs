using UnityEngine;
using System.Collections;

public class Hard_GameController : MonoBehaviour {

	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}
}
