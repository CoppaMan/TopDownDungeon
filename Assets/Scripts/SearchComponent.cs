using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchComponent<T> : MonoBehaviour{

	T component;
	bool waiting;
	int retries = 10;
	static SearchComponent<T> instance; 

	public IEnumerator search() {
		component = GetComponent<T>();
		while(component != null) {
			yield return new WaitForSeconds(0.2f);
			component = GetComponent<T>();
			retries--;
			Debug.Log("Retries left: " + retries);
		}
	}

	T find1() {
		StartCoroutine(search());
		return component;
	}

	static public T find() {
		if(!instance) instance = new SearchComponent<T>();
		return instance.find1();
	}
}
