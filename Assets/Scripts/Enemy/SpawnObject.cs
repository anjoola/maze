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
	public virtual ClearRequirement[] ClearRequirements { get { return new ClearRequirement[]{ }; } }

	// Rotation.
	public Vector3 Rotation;
}

/**
 * Represents the number of cells to clear after an object is spawned.
 */
public class ClearRequirement {
	// Direction to clear.
	public ClearDirection Direction;

	// Amount to clear.
	public int Amount;

	public ClearRequirement(ClearDirection direction, int amount) {
		Direction = direction;
		Amount = amount;
	}	
}

/**
 * Direction of clearing, relative to the current rotation of the spawn object.
 */
public enum ClearDirection : int {
	AHEAD = 0, RIGHT = 1, BEHIND = 2, LEFT = 3
};
