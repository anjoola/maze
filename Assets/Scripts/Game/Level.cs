using System.Collections;

[System.Serializable]
public class Level {
	// Whether or not the level has been completed.
	public bool isCompleted;
	
	// The floors for each level. Contains details about its size, enemies that appear, etc.
	protected Floor[] floors;

	public Level() {
		isCompleted = false;
	}
	
	public void Start() {
		// TODO
	}
	public void Finish() {
		isCompleted = true;
		
		// TODO
	}
}
