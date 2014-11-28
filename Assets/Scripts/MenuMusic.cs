using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {
    // checks whether an instance of the music object is already in scene
	private static MenuMusic instance = null;
	public static MenuMusic Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		Destroy (GameObject.FindWithTag("GameTimer"));
		Destroy (GameObject.FindWithTag("GameMusic"));
	}
}
