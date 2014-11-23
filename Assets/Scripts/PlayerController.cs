using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float playerMoveSpeed;
	private Vector3 target;
	//private bool isColliding;

	void Start(){
		playerMoveSpeed = 1.5f;
		target = transform.position;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//isColliding = true;
		transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, playerMoveSpeed * Time.deltaTime);
	}
	void OnCollisionExit2D(Collision2D collision) {
		//isColliding = false;
	}

	void FixedUpdate () { // Better for RigidBodies
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			target += Vector3.left * playerMoveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			target += Vector3.right * playerMoveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			target += Vector3.up * playerMoveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			target += Vector3.down * playerMoveSpeed * Time.deltaTime;
		}
		transform.position = Vector3.MoveTowards (transform.position, target, playerMoveSpeed * Time.deltaTime);
	} 
}
