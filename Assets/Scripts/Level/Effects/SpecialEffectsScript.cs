using UnityEngine;
using System.Collections;

/*
 * Special effects utils
 */ 

public class SpecialEffectsScript : MonoBehaviour {

	// Singleton
	public static SpecialEffectsScript INSTANCE;
	
	public ParticleSystem smokeEffect;
	public ParticleSystem disbandEffect;
	
	void Awake()
	{
		// Register singleton
		if (INSTANCE != null)
		{
			Debug.LogError("Too many instances of SpecialEffects!");
		}
		
		INSTANCE = this;
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