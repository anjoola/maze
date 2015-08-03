using System;

/**
 * Represents a game save.
 */
[System.Serializable]
public class Game {
	// Whether or not this is a new game (player has not played yet).
	public bool IsNewGame;
	// Total treasure acquired.
	public int TotalTreasure;
	// Last level played (to be shown on the game map).
	public int LastLevelPlayed;
	// Highest level unlocked.
	public int HighestLevelUnlocked;
	// Whether or not a clone has been introduced.
	public bool CloneIntroduced;
	
	public Game() {
		// TODO
		IsNewGame = true;
		TotalTreasure = 0;
		LastLevelPlayed = 1;
		HighestLevelUnlocked = 1;
		CloneIntroduced = false;
	}
}
