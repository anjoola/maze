/**
 * The sixth level.
 * 
 * TODO
 */
public class CloudLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"CloudSmall",
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
		return "Tower of Heaven";
	}}

	public CloudLevel() : base() {
		NumFloors = Floors.Length;
	}
}
