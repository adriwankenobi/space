using UnityEngine;
using System.Collections;

/// <summary>
/// Special effects utils
/// </summary>
public class SpecialEffectsScript : MonoBehaviour {

	// Singleton
	public static SpecialEffectsScript Instance;
	
	public ParticleSystem smokeEffect;
	public ParticleSystem disbandEffect;
	
	void Awake()
	{
		// Register singleton
		if (Instance != null)
		{
			Debug.LogError("Too many instances of SpecialEffects!");
		}
		
		Instance = this;
	}

	public void Boom(Vector3 position)
	{
		// Smoke
		initiate(smokeEffect, position);
		
		// Disband
		initiate(disbandEffect, position);
	}

	// Initiate the particle system
	private ParticleSystem initiate(ParticleSystem particleSystem, Vector3 position)
	{
		// Start particle effect
		ParticleSystem newParticleSystem = Instantiate(
			particleSystem,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Destroy particle effect
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}