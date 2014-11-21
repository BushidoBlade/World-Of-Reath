using UnityEngine;
using System.Collections;

public class StartMenu_OptionsButton : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("Options");
	}

}
