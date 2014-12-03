using UnityEngine;
using System.Collections;

public class OptionsMenu_Antialiasing : MonoBehaviour {

	void Awake () {
		if(QualitySettings.antiAliasing == 0) {
			guiText.text = "Antialiasing: Off";
		}
		else if(QualitySettings.antiAliasing == 2){
			guiText.text = "Antialiasing: 2x";
		}
		else if(QualitySettings.antiAliasing == 4){
			guiText.text = "Antialiasing: 4x";
		}
		else if(QualitySettings.antiAliasing == 8){
			guiText.text = "Antialiasing: 8x";
		}
	}

	void OnMouseDown () {
		if(QualitySettings.antiAliasing == 8) {
			QualitySettings.antiAliasing = 0;
			guiText.text = "Antialiasing: Off";
		}
		else if(QualitySettings.antiAliasing == 0){
			QualitySettings.antiAliasing = 2;
			guiText.text = "Antialiasing: 2x";
		}
		else if(QualitySettings.antiAliasing == 2){
			QualitySettings.antiAliasing = 4;
			guiText.text = "Antialiasing: 4x";
		}
		else if(QualitySettings.antiAliasing == 4){
			QualitySettings.antiAliasing = 8;
			guiText.text = "Antialiasing: 8x";
		}
	}
}
