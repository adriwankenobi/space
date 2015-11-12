using UnityEngine;

/*
 * Script for fire
 */

public class FireScript : MonoBehaviour {

	void Update()
	{
		// Get pauseScript from components
		PauseScript pauseSript = GameObject.Find(SpaceObjects.PAUSE_MENU).GetComponent<PauseScript>();

		// If game not paused
		if (!pauseSript.isPaused) {

			// Weapon needs to attack?
			if (InputExtensions.IsFired(gameObject)) {

				// Get player weapon
				WeaponScript weapon = GameObject.Find(SpaceObjects.PLAYER_SHIP).GetComponentInChildren<WeaponScript>();
				if (weapon != null) {
					// False because player is not the enemy
					weapon.Attack (false);
				}
			}

		}
	}
}

