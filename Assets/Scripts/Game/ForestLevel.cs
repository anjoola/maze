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
					"ExplodingEnemy",
					"StraightShootingEnemy",
					"TriggeredStraightShootingEnemy",
					"LockOnShootingEnemy",
					"RotateShootingEnemy",
				},
				new string[] {
					"TestItem"
				},
				new string[] {
					"HugeJewel",
					"JewelPile",
					"LargeJewel",
					"BigJewel",
					"HugeJewel"
				},
				1
			)
		};
	}}

	public override string LevelName { get {
		return "Forest Canopy";
	}}

	public ForestLevel() : base() {
		NumFloors = Floors.Length;
	}
}
