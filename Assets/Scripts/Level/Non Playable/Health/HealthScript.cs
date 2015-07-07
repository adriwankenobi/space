using UnityEngine;
using System.Collections;

/*
 * Behaviour of objects' health
 */

public class HealthScript : MonoBehaviour {

	public HealthItem.Type itemType;

	private HealthItem item;

	void Awake()
	{
		item = HealthItem.create(itemType);
	}

	// When collision happens
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is it a laser?
		LaserScript laser = collider.gameObject.GetComponent<LaserScript>();
		if (laser != null)
		{
			// Check if enemy or friend
			if (laser.IsEnemy != item.IsEnemy)
			{
				item.Health -= laser.Damage;
				
				// Destroy the laser
				// WARNING: Only object not the laser, or script would be destroyed as well
				Destroy(laser.gameObject);

				// If death
				if (item.Health <= 0)
				{
					SpecialEffectsScript.INSTANCE.Boom(transform.position);
					gameObject.GetComponent<AudioSource>().Play();

					if (item.IsEnemy)
					{
						transform.gameObject.GetComponent<EnemyShipScript>().Reset();
					}
					else {
						Destroy(gameObject);
					}
				}
			}
		}
	}

	public void Reset()
	{
		item.Health = item.MaxHealth;
	}
}