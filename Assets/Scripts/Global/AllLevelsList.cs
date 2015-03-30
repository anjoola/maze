using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllLevelsList : MonoBehaviour {
	/**
	 * Gets a list of all the levels in the game.
	 */
	public static List<Level> getAllLevels() {
		List<Level> levels = new List<Level>();

	
		// Underwater.
		levels.Add(new Level("Crab Meal", "CrabMeal", 500, 15));
		levels.Add(new Level("Seaweed Cave", "RockCave", 880, 15));
		levels.Add(new Level("Teamwork", "Teamwork", 600, 20));
		levels.Add(new Level("Freedom", "Freedom", 100, 10));

		// Other
		//levels.Add(new Level("Classroom Chaos", "Classroom", 100, 100));
		//levels.Add(new Level("Aerial Dangers", "BirdAndPropeller", 100, 100));

		return levels;
	}
}
