using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game {
	public List<Level> Levels;

	// Whether or not the user started the game yet.
	public bool HasStartedGame;

	public Game() {
		HasStartedGame = false;
		InitializeAllLevels();
	}
	private void InitializeAllLevels() {
		// TODO Levels.Add(new Level());
	}
}
