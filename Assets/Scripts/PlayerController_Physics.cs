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

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		playerMoveSpeed = 1000f;
		maxVelocity = 500f;
	}

	void OnCollisionEnter2D(Collision2D collider) {
		rigidbody2D.velocity = Vector3.zero;
	}

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

		if(Input.GetButton("Fire1")){
			anim.SetBool("attackLeft", true);
		}
		else
			anim.SetBool("attackLeft", false);
	}
}
