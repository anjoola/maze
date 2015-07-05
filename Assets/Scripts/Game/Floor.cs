/**
 * Represents a floor in a maze.
 */
public class Floor {
	// Scene for this floor.
	public string Scene;

	// List of enemies that appear.
	public string[] Enemies;

	// List of items that appear.
	// TODO

	// List of treasure that appear.
	// TODO

	public Floor(string scene, string[] enemies /* TODO */) {
		Scene = scene;
		Enemies = enemies;
	}
}
