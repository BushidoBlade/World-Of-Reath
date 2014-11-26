using UnityEngine;
using System.Collections;

public class PlantEnemyHealthBar : MonoBehaviour {
	private PlantEnemyHealth enemyHealth;
	public int currentEnemyHP;
	public int maxEnemyHP;
	public float newScale;
	public float currentScale;
	// Use this for initialization
	void Start () {
		renderer.material.color = new Color(0.8f, 0.0f, 0.0f);
		enemyHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		maxEnemyHP = enemyHealth.maxHealth;
		currentScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentEnemyHP == maxEnemyHP)
			renderer.enabled = false;  // no health bar on full hp
		else
			renderer.enabled = true;
		currentEnemyHP = enemyHealth.currentHealth;
		newScale = currentEnemyHP / (float)maxEnemyHP;
		transform.localScale = new Vector3 (currentScale * newScale, transform.localScale.y, transform.localScale.z);
	}
}
