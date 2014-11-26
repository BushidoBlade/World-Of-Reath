using UnityEngine;
using System.Collections;

public class PlantEnemyController : MonoBehaviour {
	public Transform target;
	public float moveSpeed;
	public int rotateSpeed;

	private Transform myTransform;

	void Awake(){
		myTransform = transform;
		moveSpeed = 1;
	}

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine( target.transform.position, myTransform.position, Color.magenta);
		myTransform.position += (target.transform.position - myTransform.position) * moveSpeed * Time.deltaTime;
	}
}
