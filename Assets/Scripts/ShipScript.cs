using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of playable ship
/// </summary>
public class ShipScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;

	void Update()
	{
		// Get direction input from keyboard
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// Move accordingly
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		// Get shoot input from keyboard
		bool shot = Input.GetButtonDown("Fire1");
		shot |= Input.GetButtonDown("Fire2");

		// Get pauseScript from components
		PauseScript pauseSript = GameObject.Find("PauseMenu").GetComponent<PauseScript>();

		// If player shoot (and game not paused)
		if (shot && !pauseSript.isPaused)
		{
			// Weapon needs to attack
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// False because player is not the enemy
				weapon.Attack(false);
				SoundEffectsScript.Instance.PlayMissileSound();
			}
		}
			
		// Verify ship is not outside from camera -> limit borders of the camera
		var distance = (transform.position - Camera.main.transform.position).z;
			
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, distance)
			).x;
			
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, distance)
			).x;
			
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, distance)
			).y;
			
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, distance)
			).y;
			
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
			
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void Awake()
	{

	}

	void Start()
	{

	}

	void Destroy()
	{

	}
	
	void OnDestroy()
	{
		// Game over, go to menu
		Application.LoadLevel("Menu");
	}
	
	void OnCollisionEnter2D(Collision2D colision)
	{

	}

	void OnCollisionExit2D(Collision2D colision)
	{

	}

	void OnTriggerEnter2D(Collider2D colisionador)
	{

	}

	void OnTriggerExit2D(Collider2D colisionador)
	{

	}
}