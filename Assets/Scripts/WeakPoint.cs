using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

	public int defense;

	public void damage(int dmg) {
		Stats stats = gameObject.GetComponent<Stats>();
		if(stats) {
			stats.takeDamage((defense <= dmg ? dmg - defense : 0));
		}
	}
}
