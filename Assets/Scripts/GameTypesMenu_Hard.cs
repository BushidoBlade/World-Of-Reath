using UnityEngine;
using System.Collections;

public class GameTypesMenu_Hard : MonoBehaviour {
	
	void OnMouseDown () {
		GameObject.Find("sceneFader").guiTexture.enabled = true;
		GameObject.Find("sceneFader").guiTexture.color = Color.Lerp(guiTexture.color, Color.black, 1.5f * Time.deltaTime);
		yield WaitForSeconds (5);
		if (guiTexture.color.a >= 0.95f) {
			// ... reload the level.
			//Application.LoadLevel(0);
			Application.LoadLevel("Arena");
		}
	}
}