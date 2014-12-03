using UnityEngine;
using System.Collections;

public class StartMenu_CreditsButton : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("Credits");
	}

}
