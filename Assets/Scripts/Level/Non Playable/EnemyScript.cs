using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy behaviour
/// </summary>

public class EnemyScript : MonoBehaviour {

	private bool isActive;
	private WeaponScript[] weapons;
	
	void Awake()
	{
		// Instantiate weapon object
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	void Start()
	{
		ChangeState(false);
	}
	
	void Update()
	{
		if (isActive == false)
		{
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				ChangeState(true);
			}
		}
		else
		{
			foreach (WeaponScript weapon in weapons) {
				// Auto shoot
				if (weapon != null && weapon.CanAttack) {
					weapon.Attack(true);
					SoundEffectsScript.Instance.PlayLightSound();
				}
			}

			// It's not in camera anymore
			if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				Destroy(gameObject);
			}
		}
	}
	
	// Enable enemy behaviour
	private void ChangeState(bool state)
	{
		isActive = state;

		// Collider
		GetComponent<Collider2D>().GetComponent<Renderer>().enabled = state;

		// Weapons
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = state;
		}
	}
}