using UnityEngine;
using System.Collections;

public class GUITextResizer20pt : MonoBehaviour {

	void Awake(){
		int baseFontSize = guiText.fontSize;
		guiText.fontSize = baseFontSize * (Screen.width / 1280);
	}
}
