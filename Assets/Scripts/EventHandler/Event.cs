using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

	Dictionary<Trigger, bool> triggers;
	int maxTriggers;
	int activeTriggers;
	List<Action> actions;
	public int eventID;

	void Awake () {
		triggers = new Dictionary<Trigger, bool>();
		actions = new List<Action>();
		maxTriggers = 0;
		activeTriggers = 0;
	}

	public void registerTrigger(Trigger trigger) {
		bool active = trigger.isActive();
		bool same = false;
		try {
			if(triggers == null) Debug.Log("dictionary not instanciated");
			triggers.Add(trigger, active);
		} catch (ArgumentException) {
			same = true;
		}
		if(!same) {
			maxTriggers++;
			activeTriggers += active ? 1 : 0;
			check();
		}
	}

	public void registerAction(Action action) {
		while(actions == null);
		actions.Add(action);
	}

	public void notify(Trigger trigger) {
		bool active = trigger.isActive();
		if(triggers[trigger] != active) {
			triggers[trigger] = active;
			activeTriggers += active ? 1 : -1;
			check();
		}
	}

	void check() {
		if (maxTriggers > 0 && activeTriggers == maxTriggers) {
			fire(true);
		} else {
			fire(false);
		}
	}

	void fire(bool status) {
		if(status) Debug.Log("Event group " + eventID + " is active");
		foreach (Action a in actions) a.notify(status);
	}
}
