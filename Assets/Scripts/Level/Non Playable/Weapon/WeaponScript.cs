using UnityEngine;
using System.Collections;

/*
 * Behaviour of weapon
 */

public class WeaponScript : MonoBehaviour {

	public WeaponItem.Type itemType;
	public Transform laser;

	private float timeBetweenShots;
	private WeaponItem item;
	
	void Awake()
	{
		item = WeaponItem.create(itemType);
	}
	
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
			timeBetweenShots = item.TimeToWaitBetweenShots;

			// Create new shot
			Transform shotObject = Instantiate(laser) as Transform;
			
			// Asign current position
			shotObject.position = transform.position;

			// Assign rotation
			shotObject.Rotate(0, 0, item.RotationZ);
			
			// If enemy fire
			LaserScript laserScript = shotObject.gameObject.GetComponent<LaserScript>();
			if (laserScript != null)
			{
				laserScript.isEnemyShot = isEnemy;
			}

			// Play laser sound
			gameObject.GetComponent<AudioSource>().Play();

			// Auto move to the right
			RigibodyMovementScript movement = shotObject.gameObject.GetComponent<RigibodyMovementScript>();
			if (movement != null)
			{
				movement.Direction = this.transform.right;
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