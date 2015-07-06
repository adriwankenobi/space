using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of weapon
/// </summary>
public class WeaponScript : MonoBehaviour {

	public Transform shotReusable;
	public float timeToWaitBetweenShots = 0.25f;
	public int type;

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

			// Assign rotation
			switch (type)
			{
				case 1:
					shotObject.Rotate(0, 0, -30);
					break;
				case 2:
					shotObject.Rotate(0, 0, 30);
					break;
				default:
					break;
			}
			
			// If enemy fire
			ShotScript shot = shotObject.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
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