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

	// Number of clones that appear.
	public int NumClones;

	public Floor(string scene, string[] enemies, string[] items, string[] treasures, int clones=0) {
		Scene = scene;
		Enemies = enemies;
		Items = items;
		Treasures = treasures;
		NumClones = clones;
	}
}
