using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	Vector2 tmp;
	Rigidbody body;
	const float walkForce = 850;
	const float turnForce = 50;
	int collisionCount;
	bool inAir;
	bool attack;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		attack = true;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		tmp = GameObject.Find("player").transform.position.xz() - transform.position.xz();
		if(!attack) tmp *= -1;
		float angle_diff = Vector2.SignedAngle(tmp, new Vector2(transform.forward.x, transform.forward.z));

		if (tmp != Vector2.zero){
			if (!inAir) body.AddForce(body.velocity.magnitude < 0.01 ? transform.forward * walkForce * 4 : transform.forward * walkForce);
			body.AddTorque(new Vector3(0,angle_diff * turnForce,0));
		}
	}

	void Update() {
		if(!attack && (GameObject.Find("player").transform.position.xz() - transform.position.xz()).magnitude > 5f) attack = true;
	}

	void OnCollisionEnter (Collision col) {
		if (collisionCount++ == 0) {
			inAir = false;
		}
		if (col.gameObject.name == "player") attack = false;
	}

	void OnCollisionExit (Collision col) {
		RaycastHit hit;
		Physics.Raycast(new Ray(transform.position, Vector3.down), out hit);
		if (--collisionCount == 0 && body.velocity.magnitude > 4 &&
			hit.distance > 1.2f) {
			body.AddForce(new Vector3(0,30000,0));
			inAir = true;
		}
	}
}
