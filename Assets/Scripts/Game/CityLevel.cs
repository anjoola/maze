/**
 * The fifth level.
 */
public class CityLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"CitySmall",
				new string[] {
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"MovingEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy"
				},
				new string[] {
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"LargeCoinPile",
					"HugeJewel",
					"LargeCoinPile",
					"CoinPile",
					"JewelPile"
				},
				3
			),
			new Floor(
				"CitySmall",
				new string[] {
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"SpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy"
				},
				new string[] {
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"LargeCoinPile",
					"HugeJewel",
					"LargeCoinPile",
					"CoinPile",
					"JewelPile"
				},
				3
			),
			new Floor(
				"CitySmall",
				new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy"
				},
				new string[] {
					"BombItem"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"LargeCoinPile",
					"HugeJewel",
					"LargeCoinPile",
					"CoinPile",
					"JewelPile"
				},
				3
			),
			new Floor(
				"CitySmall",
				new string[] { },
				new string[] {
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
					"PoisonPotion",
				},
				new string[] { },
				6
				),
				new Floor(
					"CitySmall",
					new string[] { },
				new string[] {
					"FullPotion",
					"FullPotion",
					"FullPotion",
					"FullPotion",
					"FullPotion",
					"FullPotion"
				},
				new string[] {
					"JewelPile",
					"JewelPile",
					"CoinPile",
					"LargeCoinPile",
					"HugeJewel"
				},
				3
			),
			new Floor(
				"CityMedium",
				new string[] {
					"MovingEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"LaserEnemy",
					"FasterLaserEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
				},
				new string[] {
					"TNTItem"
				},
				new string[] {
					"JewelPile",
					"SmallCoin",
					"SmallCoin",
					"MediumCoin",
					"BigCoin",
					"BigCoin",
					"BigCoin",
					"BigCoin",
					"BigCoin",
					"CoinPile",
					"LargeJewel",
					"BigJewel"
				},
				3
			),
			new Floor(
				"CityMedium",
				new string[] {
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"LaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
				},
				new string[] {
					"SmallPotion",
					"SmallPotion",
					"SeeAllGoggles"
				},
				new string[] {
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"MediumJewel",
					"LargeJewel",
					"LargeJewel",
					"BigJewel",
					"JewelPile",
					"HugeJewel"
				},
				4
			),
			new Floor(
				"CityMedium",
				new string[] {
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy"
				},
				new string[] {
					"BombItem",
					"BombItem",
					"BombItem",
					"BombItem",
					"BombItem",
					"BombItem",
					"BombItem",
					"SmallPotion",
					"SmallPotion",
					"SmallPotion"
				},
				new string[] { },
				3
			),
			new Floor(
				"CityLarge",
				new string[] {
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy"
				},
				new string[] {
					"SeeAllGoggles"
				},
				new string[] {
					"SmallCoin",
					"MediumCoin",
				},
				3
			),
			new Floor(
				"CityLarge",
				new string[] {
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy"
				},
				new string[] {
					"SeeAllGoggles",
					"LargePotion"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"HugeJewel",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
				},
				3
			),
			new Floor(
				"CityLarge",
				new string[] {
					"ExplodingEnemy",
					"ExplodingEnemy",
					"ExplodingEnemy",
					"FasterSpikeBallEnemy",
					"FasterSpikeBallEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"FasterLaserEnemy",
					"GhostEnemy",
					"GhostEnemy",
					"FasterMovingEnemy",
					"FasterMovingEnemy",
					"LockOnShootingEnemy",
					"LockOnShootingEnemy"
				},
				new string[] {
					"TNTItem"
				},
				new string[] {
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"SmallCoin",
					"HugeJewel",
					"SmallCoin",
					"MediumCoin",
					"MediumCoin",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"MediumCoin",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
					"SmallJewel",
				},
				3
			)
		};
	}}
	
	public override string LevelName { get {
		return "Metro Jungle";
	}}
	
	public CityLevel() : base() {
		NumFloors = Floors.Length;
	}
}
