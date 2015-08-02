using UnityEngine;
using System.Collections;

/**
 * Controls audio and sound effects for the game.
 */
public class AudioController : MonoBehaviour {
	public static AudioController instance;
	public AudioSource[] AudioSources;
	public static AudioSource[] AudioSourcesStatic;

	private static AudioSource currAudio;
	private static float FADE_DURATION = 1.0f;
	
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
		instance = this;
		AudioSourcesStatic = AudioSources;
	}
	
	public static AudioSource getSource(string audioName) {
		GameObject obj = Instantiate(Resources.Load("Sounds/" + audioName)) as GameObject;
		return obj.GetComponent<AudioSource>();
	}
	public static void playSFX(string audioName, float volume=1.0f) {
		Debug.Log (audioName);
		AudioSource sfx = getSource(audioName);
		
		sfx.volume = volume;
		sfx.Play();
	}
	public static void playRandomSFX(string[] choices) {
		playSFX(choices[(int) (UnityEngine.Random.value * (choices.Length - 1))]);
	}
	public static void playAudio(AudioSource src) {
		src.Play();
		if (currAudio != null)
			currAudio.Stop();
		currAudio = src;
	}
	public static void playAudio(string audioName, bool fadeIn=true) {
		AudioSource newAudio = getSource(audioName);
		
		// Play the audio and stop the previous one.
		newAudio.Play();
		if (currAudio != null)
			currAudio.Stop();
		currAudio = newAudio;
	}
	/**
	 * Plays audio across different scenes.
	 */
	public static void playContinuousAudio(int idx, bool cancelCurrent=true) {
		AudioSource newAudio = AudioSourcesStatic[idx];
		if (!newAudio.isPlaying || idx == 7) {
			if (idx == 7)
				newAudio.Stop();
			if (cancelCurrent)
				currAudio.Stop();
			newAudio.Play();
		}

		if (idx != 7)
			currAudio = newAudio;
	}

	public static AudioSource LowHealth() {
		return AudioSourcesStatic[8];
	}

	public static void halfVolume() {
		if (currAudio != null)
			currAudio.volume = 0.2f;
	}
	public static void resumeVolume() {
		if (currAudio != null)
			currAudio.volume = 1.0f;
	}

	/**
	 * Crossfade between two audio sources.
	 */
	public static void Crossfade(AudioSource a1, AudioSource a2, bool fadeIn) {
		instance.StartCoroutine(instance.CrossfadeEnum(a1, a2, fadeIn));
	}
	IEnumerator CrossfadeEnum(AudioSource a1, AudioSource a2, bool fadeIn) {
		float startTime = Time.time;
		float endTime = startTime + FADE_DURATION;
		if (!fadeIn && a2 != null || (currAudio != null && !currAudio.isPlaying)) {
			if (a1 != null) {
				a1.Stop();
				a1.volume = 1;
			}
			a2.volume = 1.0f;
		}
		while (Time.time < endTime && currAudio != null && currAudio.isPlaying) {
			float i = (Time.time - startTime) / FADE_DURATION;
			if (a1 != null) a1.volume = (1 - i);
			if (fadeIn && a2 != null) a2.volume = i;
			yield return new WaitForSeconds(0.1f);
		}
		if (a1 != null) {
			a1.Stop();
			a1.volume = 1;
		}
	}
}
