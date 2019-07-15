using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProximity : Trigger {

	public bool keepActive;
	public GameObject target;
	public float distance;
	public Constraint inequality;
	
	protected override void abstractStart () {
		active = eval((target.transform.position - gameObject.transform.position).magnitude);
		notifyNext();
	}

	void Update() {
		if(keepActive ? (!active ? true : false) : true) {
			if(eval((target.transform.position - gameObject.transform.position).magnitude) != active) {
				active = !active;
				notifyNext();
			}
		}
	}

	bool eval(float dist) {
		switch(inequality) {
			case  Constraint.Equal: return (dist == distance);
			case  Constraint.Not: return (dist != distance);
			case  Constraint.LessThan: return (dist < distance);
			case  Constraint.LessThanOrEqual: return (dist <= distance);
			case  Constraint.MoreThan: return (dist > distance);
			case  Constraint.MoreThanOrEqual: return (dist >= distance);
		}
		return  false;
	}
}