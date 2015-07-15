using UnityEngine;

/**
 * Any GameObject that will be spawned in the maze.
 */
public abstract class SpawnObject : MonoBehaviour {
	// Amount of empty cells needed in the maze to place this object, not including the cell the object will appear in.
	public virtual int SpaceNeeded { get { return 2; } }

	/**
	 * Called to clear space around where the object is spawned in order to space objects better.
	 */
	protected void ClearSpaceAround() { }
}
