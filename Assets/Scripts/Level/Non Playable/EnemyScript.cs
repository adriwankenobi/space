using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy behaviour
/// </summary>

public class EnemyScript : MonoBehaviour {

	private bool isActive;
	private WeaponScript[] weapons;
	public int distance;
	
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
				}
			}

			// It's not in camera anymore
			if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				GoBackAndNew();
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

	public void GoBackAndNew()
	{
		ChangeState(false);
		transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
		HealthScript healthSript = GetComponent<HealthScript>();
		healthSript.health = 2;
	}
}