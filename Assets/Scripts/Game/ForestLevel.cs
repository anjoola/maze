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
				
				// Enemies.
				new string[] {
					// TODO
					//"StraightShootingEnemy",
					//"StraightShootingEnemy",
					"StraightShootingEnemy"
				}
			
				// TODO
				// Items.

				// Treasures.
			)
		};
	}}

	public ForestLevel() : base() {
		NumFloors = Floors.Length;
	}
}
