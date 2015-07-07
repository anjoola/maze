/**
 * Represents a floor in a maze.
 */
public class Floor {
	// Scene for this floor.
	public string Scene;

	// List of enemies that appear.
	public string[] Enemies;

	// List of items that appear.
	public string[] Items;

	// List of treasure that appear.
	public string[] Treasures;

	public Floor(string scene, string[] enemies, string[] treasures /* TODO */) {
		Scene = scene;
		Enemies = enemies;
		Treasures = treasures;
	}
}
