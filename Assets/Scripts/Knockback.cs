using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

	public int knockBack;

	public bool getsKnockedBack;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		causeKnockBack(col.gameObject);
	}

	void causeKnockBack(GameObject target) {
		Knockback kbScript = target.GetComponent<Knockback>();
		Stats sScript = target.GetComponent<Stats>();
		if(kbScript && sScript) {
			if(kbScript.getsKnockedBack && !sScript.isInvincible()) {
				target.GetComponent<Rigidbody>().AddForce(
					(Vector3.up + transform.position - transform.position) * knockBack);
			}
		} else {
			Debug.LogWarning(target.name + " has no Knockback script attached");
		}
	}
}
