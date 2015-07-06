using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of objects' health
/// </summary>

public class HealthScript : MonoBehaviour {

	public int health = 2;
	public bool isEnemy = true;

	// When collision happens
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is it a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Check if enemy or friend
			if (shot.isEnemyShot != isEnemy)
			{
				health -= shot.damage;
				
				// Destroy the shot
				// WARNING: Only object not the shot, or script would be destroyed as well
				Destroy(shot.gameObject);

				// If death
				if (health <= 0)
				{
					SpecialEffectsScript.Instance.Boom(transform.position);
					gameObject.GetComponent<AudioSource>().Play();

					if (isEnemy)
					{
						transform.gameObject.GetComponent<EnemyScript>().GoBackAndNew();
					}
					else {
						Destroy(gameObject);
					}
				}
			}
		}
	}
}