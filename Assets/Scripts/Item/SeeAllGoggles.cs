using UnityEngine;
using System.Collections;

/**
 * Makes all maze walls invisible.
 */
public class SeeAllGoggles : Item {
	override protected void ItemEffect() {
		MainController.MazeGen.MakeMazeInvisible();
	}
}
