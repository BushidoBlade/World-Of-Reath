using UnityEngine;
using System.Collections;

public class Normal_GameController : MonoBehaviour {

	void Awake () {
		Destroy (GameObject.FindWithTag("MenuMusic"));
	}
}
