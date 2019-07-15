using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public int attackDamage;
	List<GameObject> inContact;

	// Use this for initialization
	void Awake () {
		inContact = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		WeakPoint part;
		foreach(GameObject target in inContact) {
			if(part = target.GetComponent<WeakPoint>()) {
				part.damage(attackDamage);
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		inContact.Add(col.gameObject);
	}

	void OnTriggerExit(Collider col) {
		inContact.Remove(col.gameObject);
	}
}
