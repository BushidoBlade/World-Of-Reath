using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {
	PlayerHealth pHealth;

	// Use this for initialization
	void Start () {
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			pHealth.adjustHealth (20);
			Destroy(gameObject);
		}
	}
}
