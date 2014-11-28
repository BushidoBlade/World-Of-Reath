using UnityEngine;
using System.Collections;

public class PlayerController_Physics : MonoBehaviour {
	public float playerMoveSpeed;
	public float maxVelocity;
	private float vMagnitude;
	public bool walkingDown = false;
	public bool walkingUp = false;
	public bool walkingRight = false;
	public bool walkingLeft = false;
	public bool attackLeft = false;
	public bool attackRight = false;
	public GameObject target;
	public float distance;
	public float attackTimer;
	public float attackCooldown;
	public float faceDirection;
	Animator anim;
	PlantEnemyHealth eHealth;
	PlayerHealth pHealth;
	PlantEnemyController enemyCont;
	SceneChange sceneTrans;
	private AudioSource audio1;
	private AudioSource audio2;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		playerMoveSpeed = 1000f;
		maxVelocity = 500f;
		eHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		enemyCont = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyController>();
		target = GameObject.FindWithTag("PlantEnemy");
		attackTimer = 0;
		attackCooldown = .3f;
		AudioSource[] audios = GetComponents<AudioSource>();
		audio1 = audios[0];
		audio1.volume = 0.1f;
		audio2 = audios[1];
		audio2.volume = 0.05f;
	}

	void OnCollisionEnter2D(Collision2D other) {
		//collider2D.rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.velocity = Vector3.zero;
		if (other.gameObject.tag == "SceneChange_Town") {
			sceneTrans = GameObject.FindWithTag("SceneChange_Town").GetComponent<SceneChange>();
			playerMoveSpeed = 0;
			enemyCont.sceneTransition = true;
			sceneTrans.level = "Town";
			sceneTrans.sceneEnding = true;
		}
		if (other.gameObject.tag == "SceneChange_Arena") {
			sceneTrans = GameObject.FindWithTag("SceneChange_Arena").GetComponent<SceneChange>();
			playerMoveSpeed = 0;
			enemyCont.sceneTransition = true;
			sceneTrans.level = "Arena";
			sceneTrans.sceneEnding = true;
		}
	}

	//void OnTriggerEnter2D(Collision2D Trigger){
	//	if (Trigger.gameObject.tag == 
	//}

	void Update(){
		if (pHealth.currentHealth == 0)
			playerMoveSpeed = 0;

		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		
		Vector3 temp = (target.transform.position - transform.position);
		faceDirection = temp.x;
		if (Input.GetButton("Fire1")) {
			if (attackTimer == 0 && faceDirection < 0) {
				anim.SetBool ("attackLeft", true);
				Attack();
				attackTimer = attackCooldown;
				if (!audio2.isPlaying){
					audio2.Play();
				}
			} else if (attackTimer == 0 && faceDirection > 0) {
				anim.SetBool ("attackRight", true);
				Attack();
				attackTimer = attackCooldown;
				if (!audio2.isPlaying){
					audio2.Play();
				}
			}
		}else {
			anim.SetBool ("attackLeft", false);
			anim.SetBool ("attackRight", false);
		}
	}

	void FixedUpdate () {// Better for RigidBodies
		vMagnitude = rigidbody2D.velocity.magnitude;
		if (Input.GetButton ("Horizontal") && Input.GetAxisRaw ("Horizontal") > 0) {
			if (vMagnitude < maxVelocity) { // Caps movement speed
				rigidbody2D.AddForce (Vector3.right * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool ("walkingRight", true);
			if (!audio1.isPlaying){
				audio1.Play();
			}
		} else {
			anim.SetBool ("walkingRight", false);
		}
		if (Input.GetButton ("Horizontal") && Input.GetAxisRaw ("Horizontal") < 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce (Vector3.left * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool ("walkingLeft", true);
			if (!audio1.isPlaying){
				audio1.Play();
			}
		} else {
			anim.SetBool ("walkingLeft", false);
		}
		if (Input.GetButton ("Vertical") && Input.GetAxisRaw ("Vertical") > 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce (Vector3.up * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool ("walkingUp", true);
			if (!audio1.isPlaying){
				audio1.Play();
			}
		} else {
			anim.SetBool ("walkingUp", false);
		}
		if (Input.GetButton ("Vertical") && Input.GetAxisRaw ("Vertical") < 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce (Vector3.down * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool ("walkingDown", true);
			if (!audio1.isPlaying){
				audio1.Play();
			}
		} else{
			anim.SetBool ("walkingDown", false);
		}
	}

	private void Attack(){
		distance = Vector3.Distance(target.transform.position, transform.position);
		//Vector3 dir = (target.transform.position - transform.position).normalized;
		//float direction = Vector3.Dot(dir,transform.forward);

		if (distance < 2.0f)
			eHealth.adjustHealth(-10);
		}
}
