using UnityEngine;
using System.Collections;

public class TestItem : Item {
	override protected void ItemEffect() {
		MainController.IncreaseHP(1);
	}
}
