using System;

/**
 * TODO
 */
[System.Serializable]
public class Game {
	// List of all levels in the game.
	public Level[] Levels = new Level[] {
		new ForestLevel(),
		new TowerLevel(),
		new CaveLevel(),
		new PyramidLevel(),
		new CityLevel(),
		new CloudLevel()
	};
	
	// Whether or not this is a new game (player has not played yet).
	public bool IsNewGame;
	
	public Game() {
		IsNewGame = true;
	}
}
