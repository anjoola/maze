using UnityEngine;
using System.Collections;

/**
 * Makes the player invincible for the current floor.
 */
public class InvinciblePotion : Item {
	override protected void ItemEffect() {
		MainController.BecomeInvincible();
	}
}
