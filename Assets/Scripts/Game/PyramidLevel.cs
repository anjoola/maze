/**
 * The fourth level.
 */
public class PyramidLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"PyramidSmall",
				new string[] {
					"SpikeBallEnemy",
					"StraightShootingEnemy",
					"RotateShootingEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy"
				},
				new string[] {
					"SmallPotion",
					"BombItem",
					"PoisonPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"LargeCoinPile",
					"JewelPile"
				},
				2
			),
			new Floor(
				"PyramidSmall",
				new string[] {
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy"
				},
				new string[] {
					"SmallPotion",
					"TNTItem"
				},
				new string[] {
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"HugeJewel"
				},
				2
			),
			new Floor(
				"PyramidSmall",
				new string[] {
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy"
				},
				new string[] {
					"TNTItem",
					"SeeAllGoggles"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"StraightShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"ExplodingEnemy",
					"LaserEnemy",
					"LaserEnemy"
				},
				new string[] {
					"BombItem",
					"FullPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"HugeJewel"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy"
				},
				new string[] {
					"InvinciblePotion",
					"PoisonPotion"
				},
				new string[] {
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"GhostEnemy"
				},
				new string[] {
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion"
				},
				new string[] {
					"LargeJewel",
					"SmallJewel",
					"MediumJewel",
					"JewelPile",
					"LargeJewel",
					"SmallJewel",
					"MediumJewel",
					"LargeJewel",
					"SmallJewel",
					"MediumJewel",
					"LargeJewel",
					"SmallJewel",
					"MediumJewel"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"StraightShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"ExplodingEnemy",
					"LaserEnemy",
					"LaserEnemy"
				},
				new string[] {
					"SeeAllGoggles"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"HugeJewel"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"StraightShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"ExplodingEnemy",
					"LaserEnemy",
					"LaserEnemy"
				},
				new string[] {
					"SmallPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"LargeCoinPile"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] {
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"LockOnShootingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"ExplodingEnemy",
					"LaserEnemy",
					"LaserEnemy"
				},
				new string[] {
					"SmallPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"LargeCoinPile"
				},
				2
			),
			new Floor(
				"PyramidMedium",
				new string[] { },
				new string[] {
					"SmallPotion",
					"SmallPotion",
					"SmallPotion",
					"SmallPotion",
					"SmallPotion"
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
					"SmallCoin",
					"SmallCoin",
					"SmallCoin"
				},
				2
			),
			new Floor(
				"PyramidLarge",
				new string[] { },
				new string[] {
					"InvinciblePotion"
				},
				new string[] {
					"SmallCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"LargeCoinPile"
				},
				3
				),
				new Floor(
					"PyramidLarge",
					new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"ExplodingEnemy",
					"RotateShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
				},
				3
			),
			new Floor(
				"PyramidLarge",
				new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"ExplodingEnemy",
					"RotateShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"SeeAllGoggles",
					"FullPotion"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
				},
			3
			),
			new Floor(
				"PyramidLarge",
				new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"ExplodingEnemy",
					"RotateShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"SmallPotion",
					"PoisonPotion"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
				},
				3
			),
			new Floor(
				"PyramidLarge",
				new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"ExplodingEnemy",
					"RotateShootingEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy"
				},
				new string[] {
					"BombItem",
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel"
				},
			3
			),
			new Floor(
				"PyramidLarge",
				new string[] {
					"TriggeredStraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy"
				},
				new string[] {
					"TNTItem",
					"PoisonPotion"
				},
				new string[] {
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"BigCoin",
					"BigCoin",
					"SmallJewel",
					"JewelPile",
					"SmallJewel",
					"MediumJewel",
					"HugeJewel"
				},
				3
			)
		};
	}}
	
	public override string LevelName { get {
		return "Mysterious Pyramid";
	}}
	
	public PyramidLevel() : base() {
		NumFloors = Floors.Length;
	}
}
