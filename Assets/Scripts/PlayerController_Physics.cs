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
	public float attackTimer;
	public float attackCooldown;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		playerMoveSpeed = 1000f;
		maxVelocity = 500f;
		eHealth = GameObject.FindGameObjectWithTag("PlantEnemy").GetComponent<PlantEnemyHealth>();
		pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		target = GameObject.FindGameObjectWithTag("PlantEnemy");
		attackTimer = 0;
		attackCooldown = 1.0f;
	}

	void OnCollisionEnter2D(Collision2D other) {
		other.collider.rigidbody2D.velocity = Vector3.zero;
	}

	void FixedUpdate () {// Better for RigidBodies
		if (pHealth.currentHealth == 0)
			playerMoveSpeed = 0;

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

		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;

		if(Input.GetButton("Fire1")){
			if (attackTimer == 0){
			anim.SetBool("attackLeft", true);
			Attack();
			attackTimer = attackCooldown;
			}
		}
		else
			anim.SetBool("attackLeft", false);
		if(Input.GetButton("Fire2")){
			if (attackTimer == 0){
			anim.SetBool("attackRight", true);
			Attack();
			attackTimer = attackCooldown;
			}
		}
		else
			anim.SetBool("attackRight", false);
	}
	private void Attack(){
		distance = Vector3.Distance(target.transform.position, transform.position);
		//Vector3 dir = (target.transform.position - transform.position).normalized;
		//float direction = Vector3.Dot(dir,transform.forward);
		if (distance < 2.5f)
			eHealth.adjustHealth(-10);
	}
}
