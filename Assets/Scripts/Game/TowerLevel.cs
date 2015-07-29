/**
 * The second level.
 * 
 * A tower level that is a little more difficult. An introduction to different types of treasures.
 */
public class TowerLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"TowerSmall",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"RotateShootingEnemy"
				},
				new string[] {
					"SmallPotion",
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"BigCoin",
					"SmallJewel"
				}
			),
			new Floor(
				"TowerSmall",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
				},
				new string[] {
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"LargeJewel"
				}
			),
			new Floor(
				"TowerSmall",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy"
				},
				new string[] {
					"BombItem"
					"LargePotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"JewelPile"
				}
			),
			new Floor(
				"TowerSmall",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"TriggeredStraightShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] { },
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"BigCoin",
					"BigCoin",
				    "SmallJewel",
					"SmallJewel"
				}
			),
			new Floor(
				"TowerMedium",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"LargePotion",
					"PoisonPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"HugeJewel",
				}
			),
			new Floor(
				"TowerMedium",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"BombItem"
				},
				new string[] {
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"LargeJewel",
					"HugeJewel",
					"HugeJewel",
				}
			)
		};
	}}
	
	public override string LevelName { get {
		return "Foreboding Tower";
	}}
	
	public TowerLevel() : base() {
		NumFloors = Floors.Length;
	}
}
