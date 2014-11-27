using UnityEngine;
using System.Collections;

public class PlantEnemyController : MonoBehaviour {
	public Transform target;
	public float moveSpeed;
	public int rotateSpeed;
	public float maxDistance;

	PlayerHealth pHealth;
	PlantEnemyHealth eHealth;
	NightFade night;
	public float distance;
	public float attackTimer;
	public float attackCooldown;

	public Transform spawnPoint;
	public Transform myTransform;

	public bool sceneTransition = false;

	void Awake(){
		myTransform = transform;
		GameObject player = GameObject.FindWithTag("Player");
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		eHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
		night = GameObject.FindWithTag("NightFader").GetComponent<NightFade>();
		target = player.transform;
	}

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		attackCooldown = 2.0f;
		maxDistance = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (night.isNight && !sceneTransition) {
			moveSpeed = 1;
		}else {
			myTransform.position = spawnPoint.position;
			eHealth.currentHealth = eHealth.maxHealth;
			moveSpeed = 0;
		}

		Debug.DrawLine( target.transform.position, myTransform.position, Color.magenta);
		distance = Vector3.Distance(target.transform.position, myTransform.position);
		if (eHealth.currentHealth == 0) {
			myTransform.position = spawnPoint.position;
			eHealth.currentHealth = eHealth.maxHealth;
		}
		else if (distance > maxDistance)
			myTransform.position += (target.transform.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		if (attackTimer == 0 && eHealth.currentHealth != 0) {
			Attack();
			attackTimer = attackCooldown;
		}
	}

	private void Attack(){
		if (distance < 1.6f)
			pHealth.adjustHealth(-10);
	}
}
