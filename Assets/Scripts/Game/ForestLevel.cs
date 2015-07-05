/**
 * TODO
 */
public class ForestLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"TestLevel",
				
				// Enemies.
				new string[] {
					"StraightShootingEnemy",
					"StraightShootingEnemy",
					"StraightShootingEnemy"
				}
			
				// TODO
			)
		};
	}}

	public ForestLevel() : base() {
		NumFloors = Floors.Length;
	}
}

