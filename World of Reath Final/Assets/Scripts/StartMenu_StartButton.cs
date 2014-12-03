using UnityEngine;
using System.Collections;

public class StartMenu_StartButton : MonoBehaviour {
	// Update is called once per frame
	void OnMouseDown () {
		Application.LoadLevel("GameTypesMenu");
	}
}
