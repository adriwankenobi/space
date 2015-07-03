﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of weapon
/// </summary>
public class WeaponScript : MonoBehaviour {

	public Transform shotReusable;
	public float timeToWaitBetweenShots = 0.25f;

	private float timeBetweenShots;
	
	void Start()
	{
		timeBetweenShots = 0f;
	}
	
	void Update()
	{
		// Update time passed since shot
		if (timeBetweenShots > 0)
		{
			timeBetweenShots -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			// Restart time since last shot
			timeBetweenShots = timeToWaitBetweenShots;

			// Create new shot
			Transform shotObject = Instantiate(shotReusable) as Transform;
			
			// Asign current position
			shotObject.position = transform.position;
			
			// Vemos si es fuego enemigo
			ShotScript shot = shotObject.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Auto move to the right
			MovementScript movement = shotObject.gameObject.GetComponent<MovementScript>();
			if (movement != null)
			{
				movement.direction = this.transform.right;
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return timeBetweenShots <= 0f;
		}
	}
}