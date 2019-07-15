using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter {

	float startTime, tmp;
	bool running;

	public Counter() {
		tmp = 0;
	}

	public void start() {
		if(!running) startTime = Time.realtimeSinceStartup - tmp;
		running = true;
	}

	public void stop() {
		if(running) tmp = Time.realtimeSinceStartup - startTime;
		running = false;
	}

	public void reset() {
		tmp = 0;
		startTime = Time.realtimeSinceStartup;
	}

	public float read() {
		if(running) {
			return Time.realtimeSinceStartup - startTime;
		} else {
			return tmp;
		}
	}
}
