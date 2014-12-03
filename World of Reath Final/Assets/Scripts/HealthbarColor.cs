using UnityEngine;
using System.Collections;

public class HealthbarColor : MonoBehaviour {
	private PlayerHealth playerHealth;
	private int currentPlayerHP;
	private int maxPlayerHP;
	private float newScale;
	private float currentScale;
	// Use this for initialization
	void Start () {
		renderer.material.color = new Color(0.8f, 0.0f, 0.0f);
		playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		maxPlayerHP = playerHealth.maxHealth;
		currentScale = transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
		currentPlayerHP = playerHealth.currentHealth;
		newScale = currentPlayerHP / (float)maxPlayerHP;
		transform.localScale = new Vector3 (currentScale * newScale, transform.localScale.y, transform.localScale.z);
	}
}
