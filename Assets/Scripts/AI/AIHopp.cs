using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHopp : MonoBehaviour {

	Vector2 tmp;
	Rigidbody body;
	public bool waiting;
	public bool grounded;
	public bool active;
	public AudioClip awake;
	public AudioClip hopp;
	AudioSource[] audioSource;

	// Use this for initialization
	void Awake () {
		body = GetComponent<Rigidbody>();
		//body.centerOfMass = gameObject.transform.position;
		audioSource = new AudioSource[2];
		audioSource[0] = gameObject.AddComponent<AudioSource>();
		audioSource[0].clip = awake;
		audioSource[1] = gameObject.AddComponent<AudioSource>();
		audioSource[1].clip = hopp;
	}

	public void activate() {
		audioSource[0].timeSamples = 0;
		audioSource[0].pitch = 1;
		audioSource[0].Play();
		GetComponent<Animation>()["awake"].time = 0;
		GetComponent<Animation>()["awake"].speed = 1;
		GetComponent<Animation>().Play();
		StartCoroutine(wait(1.5f));
		active = true;
	}

	public void deactivate() {
		active = false;
		audioSource[0].timeSamples = audioSource[0].clip.samples - 1;
		audioSource[0].pitch = -1;
		audioSource[0].Play();
		GetComponent<Animation>()["awake"].time = GetComponent<Animation>()["awake"].length;
		GetComponent<Animation>()["awake"].speed = -1;
		GetComponent<Animation>().Play();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(active) {
			if(!waiting && grounded) {
				tmp = (GameObject.Find("player").transform.position - transform.position).xz();
				float angle_diff = Vector2.SignedAngle(tmp, transform.forward.xz());

				body.AddForce(gameObject.transform.up*15000 + tmp.normalized.expandTo3D()*25000);
				body.angularVelocity = (gameObject.transform.up * angle_diff * 0.05f);
				StartCoroutine(wait(0.05f));
			}
		}
	}

	IEnumerator wait(float duration) {
		waiting = true;
		yield return new WaitForSeconds(duration);
		waiting = false;
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Floor") {
			audioSource[1].Play();
			grounded = true;
		}
		if(col.gameObject.tag == "Player") {
			StartCoroutine(wait(2f));
		}
	}

	void OnCollisionExit (Collision col) {
		if(col.gameObject.tag == "Floor") {
			grounded = false;
		}
	}
}
