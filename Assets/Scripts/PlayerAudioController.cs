using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour {
	public AudioClip crunch;

	void OnCollisionEnter2D(Collision2D other) {
		if( other.gameObject.tag == "Apple")
			audio.PlayOneShot(crunch, 0.7f);
	}
	// Use this for initialization
	void Start () {
	}

	void steps(){
	}

	// Update is called once per frame
	void Update () {

	}
}
