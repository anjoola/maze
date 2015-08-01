using UnityEngine;
using System.Collections;

public class StoryController : MonoBehaviour {
	public string NextScene;
	public string SceneName;

	public GameObject Image, Text;
	public float Delay = 4;

	void Start() {
		AudioController.playAudio(SceneName);

		iTween.MoveFrom(Text, iTween.Hash("y", -58, "easetype", "linear", "time", 0.4f, "delay", 0.1f));
		iTween.MoveFrom(Image, iTween.Hash("y", 1, "easetype", "linear", "time", 0.7f, "delay", 0.1f));
		
		iTween.MoveBy(Text, iTween.Hash("y", -4, "loopType", "pingpong", "easetype", "linear", "time", 0.7));
		iTween.MoveBy(Image, iTween.Hash("y", 0.008f, "looptype", "pingpong", "easetype", "linear", "time", 0.7f));
		
		iTween.MoveTo(Text, iTween.Hash("y", -58, "easetype", "linear", "time", 0.6f, "delay", Delay));
		iTween.MoveTo(Image, iTween.Hash("y", 1, "easetype", "linear", "time", 0.7f, "delay", Delay));

		StartCoroutine(Fade());
	}

	IEnumerator Fade() {
		yield return new WaitForSeconds(Delay + 0.5f);
		AutoFade.LoadLevel(NextScene, 0.1f, 0.1f, Color.black);
	}
}
