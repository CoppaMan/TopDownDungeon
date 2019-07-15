using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

	public bool local;
	public int eventID;

	// Use this for initialization
	void Start () {
		if(!local) {
			Event thisEvent = Array.Find(GameObject.FindGameObjectWithTag("Event").GetComponents<Event>(), e => e.eventID == eventID);
			thisEvent.registerAction(this);
		}
		abstractStart();
	}

	protected abstract void abstractStart();

	public abstract void notify(bool status);
}
