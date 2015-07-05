using UnityEngine;
using System.Collections;

public class TitleScreenController : MonoBehaviour {
	void Update() {
		if (Input.GetMouseButtonDown(0))
			AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
	}
}
