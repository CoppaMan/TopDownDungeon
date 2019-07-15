using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relative : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;
	public bool global;

	void Update () {
		transform.position = global ? target.transform.position + offset : target.transform.position +
			(target.transform.up*offset.y) + (target.transform.forward*offset.z) + (target.transform.right*offset.x);
	}
}
