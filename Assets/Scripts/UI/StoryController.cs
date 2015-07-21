using UnityEngine;
using System.Collections;

public class StoryController : MonoBehaviour {
	public string NextScene;
	
	void Update() {
		if (Input.GetMouseButtonDown(0))
			AutoFade.LoadLevel(NextScene, 0.2f, 0.2f, Color.black);
	}
}
