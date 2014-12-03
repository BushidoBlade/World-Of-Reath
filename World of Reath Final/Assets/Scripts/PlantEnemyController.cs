using UnityEngine;
using System.Collections;

public class PlantEnemyController : MonoBehaviour {
	private Transform target;
	public float moveSpeed;
	private float maxDistance;
	
	PlayerHealth pHealth;
	PlantEnemyHealth eHealth;
	NightFade night;
	private float distance;
	private float attackTimer;
	public float attackCooldown;
	
	private Transform spawnPoint;
	private Transform myTransform;
	Animator anim;
	public bool sceneTransition = false;
	public GameObject itemDrop;
	private float faceDirection;
	private AudioSource audio1;
	private AudioSource audio2;

	void Awake(){
		myTransform = transform;
		GameObject player = GameObject.FindWithTag("Player");
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		eHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
		night = GameObject.FindWithTag("NightFader").GetComponent<NightFade>();
		target = player.transform;
		anim = GetComponent<Animator>();
		AudioSource[] audios = GetComponents<AudioSource>();
		audio1 = audios[0];
		audio2 = audios[1];
		audio2.volume = 0.25f;
	}
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		attackCooldown = 1.0f;
		maxDistance = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (sceneTransition) {
			moveSpeed = 0f;
		} else if (night.isNight) {
			moveSpeed = 1.3f;
		} else {
			moveSpeed = 2f;
		}
		Debug.DrawLine( target.transform.position, myTransform.position, Color.magenta);
		distance = Vector3.Distance(target.transform.position, myTransform.position);
		if (eHealth.currentHealth == 0) {
			audio2.Play();
			Instantiate(itemDrop, myTransform.position, Quaternion.identity);
			myTransform.position = spawnPoint.position;
			eHealth.currentHealth = eHealth.maxHealth;
		}
		else if (distance > maxDistance && night.isNight)
			myTransform.position += (target.transform.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
		else if(!night.isNight)
			myTransform.position += (spawnPoint.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		if (attackTimer == 0 && eHealth.currentHealth != 0) {
			Attack();
			attackTimer = attackCooldown;
		}

		Vector3 temp = (target.transform.position - transform.position);
		if (!night.isNight)
			temp = (spawnPoint.position - myTransform.position);
		faceDirection = temp.x;
		if (faceDirection < 0) {
			anim.SetBool("plantLeft", true);
			anim.SetBool("plantRight", false);
		} else if (faceDirection > 0) {
			anim.SetBool("plantLeft", false);
			anim.SetBool("plantRight", true);
		}
	}
	
	private void Attack(){
		if (distance < 1.1f) {
			if (pHealth.currentHealth != 0)
				audio1.Play();
			pHealth.adjustHealth (-30);
		}
	}
}
