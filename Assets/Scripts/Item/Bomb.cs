using UnityEngine;
using System.Collections;

public class Bomb : Item {
	public int Blocks = 3;
	override protected void ItemEffect() {
		MainController.MazeGen.DestroyEnemiesWithin(player.transform.position, Blocks);
	}
}
