using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody body;
	public float acceleration;
	public Stats stats;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		Vector2 tmp = Input.GetKey(KeyCode.W) ? new Vector2(0,1) : Vector2.zero; 
		tmp += Input.GetKey(KeyCode.A) ? new Vector2(-1,0) : Vector2.zero;
		tmp += Input.GetKey(KeyCode.S) ? new Vector2(0,-1) : Vector2.zero;
		tmp += Input.GetKey(KeyCode.D) ? new Vector2(1,0) : Vector2.zero;
		tmp.Normalize();

		float angle_diff = Vector2.SignedAngle(tmp, transform.forward.xz());

		if (tmp != Vector2.zero){
			body.velocity += tmp.expandTo3D() * Time.deltaTime * acceleration;
			body.angularVelocity = gameObject.transform.up * angle_diff * 0.1f;
		} else {
			if(body.velocity.xz().magnitude <= 0.001f) {
				body.velocity = new Vector3(0, body.velocity.y, 0);
			} else {
				body.velocity *= 0.9f;
			}
			if(Mathf.Abs(body.angularVelocity.y) <= 0.001f) {
				body.angularVelocity = Vector3.zero;
			} else {
				body.angularVelocity *= 0.9f;
			}
		}
	}
	
	void Update() {
		if(Input.GetKey(KeyCode.Q)) {
			GetComponentInChildren<Animation>().Play();
		}
	}
}
