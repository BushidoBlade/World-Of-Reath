using UnityEngine;
using System.Collections;

public class PlayerController_Physics : MonoBehaviour {
	public float playerMoveSpeed;
	public float maxVelocity;
	private float vMagnitude;
	Animator anim;
	public bool walkingDown = false;
	public bool walkingUp = false;
	public bool walkingRight = false;
	public bool walkingLeft = false;
	public bool attackLeft = false;
	public bool attackRight = false;
	public GameObject target;
	public float distance;
	PlantEnemyHealth eHealth;
	PlayerHealth pHealth;
	PlantEnemyController enemyCont;
	public float attackTimer;
	public float attackCooldown;
	public float faceDirection;
	SceneChange_Town sceneTrans;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		playerMoveSpeed = 1000f;
		maxVelocity = 500f;
		eHealth = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
		enemyCont = GameObject.FindWithTag("PlantEnemy").GetComponent<PlantEnemyController>();
		target = GameObject.FindWithTag("PlantEnemy");
		sceneTrans = GameObject.FindWithTag("SceneChange_Town").GetComponent<SceneChange_Town>();
		attackTimer = 0;
		attackCooldown = .6f;
	}

	void OnCollisionEnter2D(Collision2D other) {
		//collider2D.rigidbody2D.velocity = Vector3.zero;
		rigidbody2D.velocity = Vector3.zero;
		if (other.gameObject.tag == "SceneChange_Town") {
			playerMoveSpeed = 0;
			enemyCont.sceneTransition = true;
			sceneTrans.sceneEnding = true;
		}
	}

	//void OnTriggerEnter2D(Collision2D Trigger){
	//	if (Trigger.gameObject.tag == 
	//}

	void FixedUpdate () {// Better for RigidBodies
		vMagnitude = rigidbody2D.velocity.magnitude;
		if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) {
			if (vMagnitude < maxVelocity) { // Caps movement speed
				rigidbody2D.AddForce(Vector3.right * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool("walkingRight",true);
		}
		else
			anim.SetBool("walkingRight",false);
		if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce(Vector3.left * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool("walkingLeft",true);
		}
		else
			anim.SetBool("walkingLeft",false);
		if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce(Vector3.up * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool("walkingUp", true);
		}
		else
			anim.SetBool("walkingUp",false);
		if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0) {
			if (vMagnitude < maxVelocity) {
				rigidbody2D.AddForce(Vector3.down * playerMoveSpeed * Time.deltaTime);
			}
			anim.SetBool("walkingDown", true);
		}
		else
			anim.SetBool("walkingDown", false);
	}

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
				Attack ();
				attackTimer = attackCooldown;
			} else if (attackTimer == 0 && faceDirection > 0) {
				anim.SetBool ("attackRight", true);
				Attack ();
				attackTimer = attackCooldown;
			}
		}else {
			anim.SetBool ("attackLeft", false);
			anim.SetBool ("attackRight", false);
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
