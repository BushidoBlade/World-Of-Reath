using UnityEngine;
using System.Collections;

public class PlayerHealthTracker : MonoBehaviour {
	private static PlayerHealthTracker instance = null;
	public static PlayerHealthTracker Instance {
		get { return instance; }
	}
	public int currentPlayerhealth;
	PlayerHealth pHealth;

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		currentPlayerhealth = 100;
	}
}
