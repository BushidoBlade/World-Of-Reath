using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
	private static GameTimer instance = null;
	public static GameTimer Instance {
		get { return instance; }
	}
	public int gameTimer = 0;

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

		InvokeRepeating("incrTimer", 0, 1.0f);
	}

	void Start(){
	}

	void incrTimer(){
		gameTimer++;
	}
}
