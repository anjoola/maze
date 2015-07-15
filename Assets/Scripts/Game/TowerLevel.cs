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
					"StraightShootingEnemy",
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
		return "Foreboding Tower";
	}}
	
	public TowerLevel() : base() {
		NumFloors = Floors.Length;
	}
}
