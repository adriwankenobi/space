using UnityEngine;
using System.Collections;

/// <summary>
/// Sound effects utils
/// </summary>
public class SoundEffectsScript : MonoBehaviour {

	// Singleton
	public static SoundEffectsScript Instance;
	
	public AudioClip boomSound;
	public AudioClip missileSound;
	public AudioClip lightSound;
	
	void Awake()
	{
		// Register singleton
		if (Instance != null)
		{
			Debug.LogError("Too many instances of SoundEffects!");
		}
		Instance = this;
	}
	
	public void PlayBoomSound()
	{
		PlaySound(boomSound);
	}
	
	public void PlayMissileSound()
	{
		PlaySound(missileSound);
	}
	
	public void PlayLightSound()
	{
		PlaySound(lightSound);
	}

	private void PlaySound(AudioClip clip)
	{
		// Not 3D sound, so position don't matter
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}