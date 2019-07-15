using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealth : Trigger {

	public int targetHealth;
	public Constraint inequality;
	protected override void abstractStart () {return;}

	public void notifyTrigger(int health){
		switch(inequality) {
			case  Constraint.Equal: active = (health == targetHealth); break;
			case  Constraint.Not: active = (health != targetHealth); break;
			case  Constraint.LessThan: active = (health < targetHealth); break;
			case  Constraint.LessThanOrEqual: active = (health <= targetHealth); break;
			case  Constraint.MoreThan: active = (health > targetHealth); break;
			case  Constraint.MoreThanOrEqual: active = (health >= targetHealth); break;
		}
		notifyNext();
	}
}