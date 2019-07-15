using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour {

	protected bool active;
	public int eventID;
	public bool local;
	protected Event thisEvent;
	protected Action thisAction;

	// Use this for initialization
	void Start () {
		if(local) {
			thisAction = GetComponent<Action>();
		} else {
			thisEvent = Array.Find(GameObject.FindGameObjectWithTag("Event").GetComponents<Event>(), e => e.eventID == eventID);
			thisEvent.registerTrigger(this);
		}
		abstractStart();
	}

	protected abstract void abstractStart();

	protected void notifyNext() {
		if(local) {
			if(!thisAction) {
				Debug.LogWarning(gameObject.name + "is in local mode but has no Action attached!");
				return;
			}
			thisAction.notify(active);
		} else {
			if(!thisEvent) {
				Debug.LogWarning(gameObject.name + " cannot find EventHandler with ID " + eventID + "!");
				return;
			}
			thisEvent.notify(this);
		}
	}

	public bool isActive() {
		return active;
	}
}
