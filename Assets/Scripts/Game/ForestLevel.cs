/**
 * The first level.
 * 
 * A forest level that is small and simple with few enemies. An introduction.
 */
public class ForestLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"ForestSmall",
				new string[] {
					"ExplodingEnemy",
					"StraightShootingEnemy",
				},
				new string[] {
					"TestItem"
				},
				new string[] {
					"TestTreasure"
				}
			),

			new Floor(
				"ForestSmall",
				new string[] {
					// TODO
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy"
				},
				new string[] {
					"TestItem"
				},
				new string[] {
					"TestTreasure"
				}
			),

			new Floor(
				"ForestSmall",
				new string[] {
					// TODO
					"RotateShootingEnemy",
					"RotateShootingEnemy",
					"StraightShootingEnemy"
				},
				new string[] {
					"TestItem"
				},
				new string[] {
					"TestTreasure"
				}
			),

			new Floor(
				"TestLevel",
				new string[] {
					// TODO
					"ExplodingEnemy",
					"ExplodingEnemy"
				},
				new string[] {
					"TestItem"
				},
				new string[] {
					"TestTreasure"
				}
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
