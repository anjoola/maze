using UnityEngine;
using System.Collections;

public class HealthPotion : Item {
	public int HPIncreaseAmount = 1;

	override protected void ItemEffect() {
		MainController.IncreaseHP(HPIncreaseAmount);
	}
}
