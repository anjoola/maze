using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level {
	// Whether or not the level has been completed.
	public bool isCompleted;
	
	// TODO info about the level such as the type of enemies, etc.?
	
	public Level() {
		isCompleted = false;
	}
	
	public void start() {
		// TODO
	}
	public void finish() {
		isCompleted = true;
		
		// TODO
	}
}
