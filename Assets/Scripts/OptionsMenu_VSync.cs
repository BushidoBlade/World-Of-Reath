using UnityEngine;
using System.Collections;

public class OptionsMenu_VSync : MonoBehaviour {

	void Awake (){
		if(QualitySettings.vSyncCount == 0){
			guiText.text = "vSync: Off";
		}
		else{
			guiText.text = "vSync: On";
		}
	}


	void OnMouseDown () {
		if(QualitySettings.vSyncCount == 1){
			QualitySettings.vSyncCount = 0;
			guiText.text = "vSync: Off";
		}
		else if(QualitySettings.vSyncCount == 0){
			QualitySettings.vSyncCount = 1;
			guiText.text = "vSync: On";
		}
	}
}
