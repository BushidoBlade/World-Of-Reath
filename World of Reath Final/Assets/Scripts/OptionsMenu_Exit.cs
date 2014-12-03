using UnityEngine;
using System.Collections;

public class OptionsMenu_Exit : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("StartMenu");
	}
}
