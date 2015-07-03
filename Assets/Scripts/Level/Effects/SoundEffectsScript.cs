using UnityEngine;
using System.Collections;

/// <summary>
/// Sound effects utils
/// </summary>
public class SoundEffectsScript : MonoBehaviour {

	// Singleton
	public static SoundEffectsScript Instance;
	
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
		gameObject.GetComponent<AudioSource>().Play();
	}
}