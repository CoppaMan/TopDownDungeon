using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public int maxHealth;
	int health;
	public int strength;
	bool invincible;
	public float invTime;
	TriggerHealth healthTrigger;

	void Start() {
		if (maxHealth <= 0) maxHealth = 1;
		if (invTime <= 0) invTime = 0.1f;
		health = maxHealth;
		healthTrigger = gameObject.GetComponent<TriggerHealth>();
	}

	public int getHealth() { return this.health; }

	public void takeDamage(int damage) {
		if(!invincible) {
			invincible = true;
			health -= damage <= health ? damage : health;
			if(healthTrigger) healthTrigger.notifyTrigger(health);
			StartCoroutine(invTimeout());
		}
	}

	IEnumerator invTimeout() {
		invincible = true;
		yield return new WaitForSeconds(invTime);
		invincible = false;
	}

	public bool isInvincible() {
		return invincible;
	}
}
