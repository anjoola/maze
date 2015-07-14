/**
 * The first level.
 * 
 * A forest level that is small and simple with few enemies. An introduction.
 */
public class ForestLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"TestLevel",
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

	public ForestLevel() : base() {
		NumFloors = Floors.Length;
	}
}
