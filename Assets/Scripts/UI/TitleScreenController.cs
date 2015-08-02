using UnityEngine;
using System.Collections;

public class TitleScreenController : MonoBehaviour {
	public GameObject Treasures;

	void Start() {
		iTween.ScaleBy(Treasures, iTween.Hash("x", 1.1f, "y", 1.1f, "z", 1.1f, "easetype", "linear",
		                                      "looptype", "pingPong", "time", 1.0f));
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			// TODO uncomment everything
			//if (MainController.CurrentGame.IsNewGame)
				//AutoFade.LoadLevel("Story1", 0.2f, 0.2f, Color.black);
			//else
				AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
		}
	}
}
