using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour {

	public int damage;

	List<GameObject> collisions;

	// Use this for initialization
	void Start () {
		collisions = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject body in collisions) {
			if(body.gameObject.GetComponent<Stats>()) {
				body.GetComponent<Stats>().takeDamage(damage + GetComponent<Stats>().strength);
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		collisions.Add(col.gameObject);
	}

	void OnCollisionExit (Collision col) {
		collisions.Remove(col.gameObject);
	}
}
