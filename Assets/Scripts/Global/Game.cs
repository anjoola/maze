using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game {
	// TODO public List<Level> levels;
	
	// Whether or not the user played the game yet. Set to false if this it the first time the user
	// has played the game.
	public bool played;
	
	public Game() {
		played = false;
	}
}
