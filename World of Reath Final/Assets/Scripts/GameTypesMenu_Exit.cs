using UnityEngine;
using System.Collections;

public class GameTypesMenu_Exit : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("StartMenu");
	}
}
