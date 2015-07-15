/**
 * The third level.
 * 
 * TODO
 */
public class CaveLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"CaveSmall",
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
		return "Deep Cave";
	}}
	
	public CaveLevel() : base() {
		NumFloors = Floors.Length;
	}
}
