using UnityEngine;
using System.Collections;

/**
 * Makes the player invincible for the current floor.
 */
public class InvinciblePotion : Item {
	public override string ItemName { get { return "Invincible"; } }

	override protected void ItemEffect() {
		MainController.BecomeInvincible();
	}
}
