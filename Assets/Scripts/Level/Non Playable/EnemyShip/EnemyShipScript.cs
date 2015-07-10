using UnityEngine;
using System.Collections;

/*
 * Enemy ship behaviour
 */

public class EnemyShipScript : MonoBehaviour {

	private const int OFFSET = 20;

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
				if (weapon != null) {
					weapon.Attack(true);
				}
			}

			// It's not in camera anymore
			if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				Reset();
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

	// Reset ship
	public void Reset()
	{
		ChangeState(false);
		transform.position = new Vector3(transform.position.x + OFFSET, transform.position.y, transform.position.z);
		GetComponent<HealthScript>().Reset();
	}
}