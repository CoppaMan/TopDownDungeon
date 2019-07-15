using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAwakeAI : Action {

	public bool inverted;
	AIHopp ai;

	protected override void abstractStart() {
		if((ai = gameObject.GetComponent<AIHopp>()) == null) Debug.LogError("No AI attached to " + gameObject.name + " to make " + name + " work!");
	}

	public override void notify(bool status) {
		if(inverted ? !status : status) {
			ai.activate();
		} else {
			ai.deactivate();
		}
	}
}
