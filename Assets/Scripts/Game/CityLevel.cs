/**
 * The fifth level.
 * 
 * TODO
 */
public class CityLevel : Level {
	public override Floor[] Floors { get {
		return new Floor[] {
			new Floor(
				"CitySmall",
				new string[] {
					"StraightShootingEnemy",
				},
				new string[] {
				},
				new string[] {
				}
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
