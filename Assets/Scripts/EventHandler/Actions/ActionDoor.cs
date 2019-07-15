using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDoor : Action {

	public bool inverted;

	protected override void abstractStart() {
		GetComponent<Collider>().enabled = !inverted;
	}

	public override void notify(bool status) {
		GetComponent<Collider>().enabled = (inverted ? status : !status);
		Debug.Log(gameObject.name + " is " + ((inverted ? !status : status) ? "open" : "closed"));
	}
}
