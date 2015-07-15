/**
 * The fourth level.
 * 
 * TODO
 */
public class PyramidLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"PyramidSmall",
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
		return "Mysterious Pyramid";
	}}
	
	public PyramidLevel() : base() {
		NumFloors = Floors.Length;
	}
}
