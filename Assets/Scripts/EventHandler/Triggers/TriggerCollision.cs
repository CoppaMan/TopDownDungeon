using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : Trigger {

	public float duration;
	Counter counter;
	int activators;

	protected override void abstractStart () {
		counter = new Counter();
	}
	
	// Update is called once per frame
	void Update () {
		if(duration != 0) {
			if(counter.read() > duration) {
				active = false;
				notifyNext();
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Interactable" && activators++ == 0) {
			Debug.Log(gameObject.name + " was activated by " + col.gameObject.name);
			counter.stop();
			counter.reset();
			active = true;
			notifyNext();
		}
	}

	void OnCollisionExit (Collision col) {
		if(col.gameObject.tag == "Movable" && --activators < 1) counter.start();
	}
}
