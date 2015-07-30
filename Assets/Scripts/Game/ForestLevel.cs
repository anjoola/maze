/**
 * The first level.
 * 
 * A forest level that is small and simple with few enemies. An introduction.
 */
public class ForestLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"ForestMedium",
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
					"MovingEnemy"
				},
				new string[] {
					"SmallPotion",
					"InvinciblePotion",
					"PoisonPotion",
					"FullPotion",
					"TNTItem",
					"BombItem",
					"SeeAllGoggles"
				},
				new string[] {
					"HugeJewel",
					"JewelPile",
					"LargeJewel",
					"BigJewel",
					"HugeJewel",
					"SmallCoin",
					"MediumCoin",
					"BigCoin",
					"CoinPile",
					"LargeCoinPile"
				}
			),
			new Floor(
				"ForestSmall",
				new string[] {
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy"
				},
				new string[] {
					"SmallPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin"
				}
			),
			new Floor(
				"ForestSmall",
				new string[] {
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"RotateShootingEnemy"
				},
				new string[] { },
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel"
				}
			),
			new Floor(
				"ForestSmall",
				new string[] {
					"StraightShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy"
				},
				new string[] {
					"SmallPotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"LargeCoinPile"
				}
			),
			new Floor(
				"ForestSmall",
				new string[] {
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy"
				},
				new string[] {
					"SmallPotion",
					"LargePotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel"
				}
			),
			new Floor(
				"ForestMedium",
				new string[] {
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy"
				},
				new string[] {
					"LargePotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"CoinPile"
				}
			),
		};
	}}

	public override string LevelName { get {
		return "Forest Canopy";
	}}

	public ForestLevel() : base() {
		NumFloors = Floors.Length;
	}
}
