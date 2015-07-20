using UnityEngine;
using System.Collections;

public class HealthPotion : Item {
	public int HPIncreaseAmount = 1;

	override protected void ItemEffect() {
		if (HPIncreaseAmount < 0)
			MainController.DecreaseHP(-HPIncreaseAmount);
		else
			MainController.IncreaseHP(HPIncreaseAmount);
	}
}
