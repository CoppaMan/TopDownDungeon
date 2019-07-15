using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public Texture heart;
	const int margin = 5;
	const int size = 20;

	void start() {
	}
	
	void OnGUI() {
		int health = GameObject.Find("player").GetComponent<Stats>().getHealth();

		for(int i = 0; i < health; i++) {
			GUI.DrawTexture(new Rect(5 + (size + margin)*i,margin,size,size), heart, ScaleMode.ScaleToFit, true, 1f);
		}
 	} 
}
