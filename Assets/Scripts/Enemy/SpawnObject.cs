using UnityEngine;

/**
 * Any GameObject that will be spawned in the maze.
 */
public abstract class SpawnObject : MonoBehaviour {
	// Amount of empty cells needed in the maze to place this object, not including the cell the object will appear in.
	public int SpaceNeeded = 2;
}
