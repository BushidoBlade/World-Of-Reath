using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {
	PlantEnemyHealth eHealth;
	PlayerHealth pHealth;
	public Transform myTransform;
	public Transform pEnemyTrans;
	public Transform foodSpawn;
	// Use this for initialization
	void Start () {
		eHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		foodSpawn = GameObject.FindWithTag ("SpawnPointFood").transform;
		myTransform = transform;
		pEnemyTrans = GameObject.FindWithTag("PlantEnemy").transform;
	}

	//void OnTriggerEnter2D(Collision2D Trigger) {
	//	myTransform.position = foodSpawn.position;
	//	pHealth.adjustHealth(20);
	//}
	void OnCollisionEnter2D(Collision2D Trigger) {
		myTransform.position = foodSpawn.position;
		pHealth.adjustHealth(20);
	}



	// Update is called once per frame
	void Update () {
		if (eHealth.currentHealth == 0) {
			myTransform.position = pEnemyTrans.position;
		}

	}
}
