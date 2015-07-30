using UnityEngine;
using System.Collections;

/**
 * Makes all maze walls invisible.
 */
public class SeeAllGoggles : Item {
	public override string ItemName { get { return "SeeAllGoggles"; } }

	override protected void ItemEffect() {
		MainController.MazeGen.MakeMazeInvisible();
	}
}
