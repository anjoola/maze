using UnityEngine;
using System.Collections;

/**
 * Controls audio and sound effects for the game.
 */
public class AudioController : MonoBehaviour {
	// How long to cross-fade.
	private static float FADE_DURATION = 1.0f;

	public static AudioController instance;
	public AudioSource[] AudioSources;
	public static AudioSource[] AudioSourcesStatic;

	// Current audio and SFX being played.
	private static AudioSource currAudio;
	private static AudioSource currSFX;
	private static string[] currSFXArray;
	private static float LastSFXTime = -1f;

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
		instance = this;
		AudioSourcesStatic = AudioSources;
	}

	/**
	 * Instantiate the audio prefab with the given name.
	 */
	public static AudioSource getSource(string audioName) {
		GameObject obj = Instantiate(Resources.Load("Sounds/" + audioName)) as GameObject;
		return obj.GetComponent<AudioSource>();
	}

	/**
	 * Play the SFX with the given name.
	 */
	public static void playSFX(string audioName, float volume=1.0f) {
		// Don't play the same SFX twice within a short period.
		if (currSFX != null && currSFX.name.Equals(audioName + "(Clone)") && Time.time - LastSFXTime < 0.5f)
			return;

		if (currSFX != null)
			Destroy(currSFX.gameObject);
		AudioSource sfx = getSource(audioName);
		
		sfx.volume = volume;
		sfx.Play();
		currSFX = sfx;
		LastSFXTime = Time.time;
	}

	/**
	 * Play a randomly chosen SFX from an array.
	 */
	public static void playRandomSFX(string[] choices) {
		// Don't play the same kind of SFX within a short period.
		if (currSFXArray != null && currSFXArray == choices && Time.time - LastSFXTime < 0.5f)
			return;

		currSFXArray = choices;
		playSFX(choices[(int) (UnityEngine.Random.value * (choices.Length - 1))]);
	}

	/**
	 * Play an audio source.
	 */
	public static void playAudio(AudioSource src) {
		src.Play();
		if (currAudio != null)
			currAudio.Stop();
		currAudio = src;
	}

	/**
	 * Play an audio file.
	 */
	public static void playAudio(string audioName, bool fadeIn=true) {
		AudioSource newAudio = getSource(audioName);
		
		// Play the audio and stop the previous one.
		newAudio.Play();
		if (currAudio != null)
			currAudio.Stop();
		currAudio = newAudio;
	}

	/**
	 * Play audio across different scenes.
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
