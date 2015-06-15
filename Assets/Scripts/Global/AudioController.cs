using UnityEngine;
using System.Collections;

// Plays audio files and adjusts the volume.
public class AudioController : MonoBehaviour {
	public static AudioController instance;
	
	float FADE_DURATION = 1.0f;
	static float HALF_VOLUME = 0.3f;

	// The currently-playing audio.
	private static AudioSource CurrentAudio;

	void Awake() {
		instance = this;
	}

	// Get the audio source associated with this name.
	private static AudioSource GetAudioSource(string name) {
		GameObject obj = Instantiate(Resources.Load(name)) as GameObject;
		obj.transform.position = MainUIController.instance.transform.position;
		return obj.GetComponent<AudioSource>();
	}
	// Plays the given audio file. If fadeIn is set to true, crossfades this audio source with the currently-playig one.
	public static void PlayAudio(string name, bool fadeIn=true) {
		AudioSource audio = GetAudioSource(name);

		// Play the audio.
		audio.volume = 0;
		audio.Play();

		// Immediately play the new audio file if no fading required.
		if (!fadeIn) {
			audio.volume = 1.0f;
			CurrentAudio.Stop();
			// TODO handle deleting object
		}
		// Otherwise, fade out old audio and fade in new one.
		else {
			Crossfade(CurrentAudio, audio);
		}
		CurrentAudio = audio;
	}
	public static void PlaySFX(string name) {
		AudioSource sfx = GetAudioSource(name);

		sfx.volume = 1.0f;
		sfx.Play();

		// TODO handle destroying audio file afterwards
	}

	public static void ReduceVolume() {
		AudioListener.volume = HALF_VOLUME;
	}
	public static void ResumeVolume() {
		AudioListener.volume = 1.0f;
	}
	
	private static void Crossfade(AudioSource a1, AudioSource a2) {
		instance.StartCoroutine(instance.CrossfadeEnum(a1, a2));
	}
	IEnumerator CrossfadeEnum(AudioSource a1, AudioSource a2) {
		float startTime = Time.time;
		float endTime = startTime + FADE_DURATION;

		while (Time.time < endTime) {
			float i = (Time.time - startTime) / FADE_DURATION;
			if (a1 != null) a1.volume = (1 - i);
			a2.volume = i;
			yield return new WaitForSeconds(0.1f);
		}
		if (a1 != null) a1.Stop();
		// TODO handle deleting object
	}

	// TODO
	public static void PlayButtonPress() {
		ResumeVolume();
		//AudioController.playSFX("ButtonPress", 2.0f);
	}
	public static void timerBeep() {
		//AudioController.playSFX("Beep", 1.0f);
	}
}
