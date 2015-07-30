using UnityEngine;
using System.Collections;

/**
 * Destroys all enemies within a certain distance from the player.
 */
public class Bomb : Item {
	public override string ItemName { get { return "Bomb"; } }

	public int Blocks = 3;

	override protected void ItemEffect() {
		MainController.MazeGen.DestroyEnemiesWithin(player.transform.position, Blocks);
	}
}
