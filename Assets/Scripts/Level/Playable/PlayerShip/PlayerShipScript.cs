using UnityEngine;
using System.Collections;

/*
 * Behaviour of playable ship
 */

public class PlayerShipScript : MonoBehaviour {

	public RigibodyMoveItem.Type itemType;
	
	private RigibodyMoveItem item;
	private Vector2 movement;
	
	void Awake()
	{
		item = RigibodyMoveItem.create(itemType);
	}

	void Update()
	{
		// Get direction input from keyboard
		float inputX = Input.GetAxis(Inputs.HORIZONTAL);
		float inputY = Input.GetAxis(Inputs.VERTICAL);
		
		// Move accordingly
		movement = new Vector2(
			item.Speed.x * inputX,
			item.Speed.y * inputY);

		// Get shoot input from keyboard
		bool shot = Input.GetButtonDown(Inputs.FIRE_1) | Input.GetButtonDown(Inputs.FIRE_2);

		// Get pauseScript from components
		PauseScript pauseSript = GameObject.Find(SpaceObjects.PAUSE_MENU).GetComponent<PauseScript>();

		// If player shoot (and game not paused)
		if (shot && !pauseSript.isPaused)
		{
			// Weapon needs to attack
			WeaponScript weapon = GetComponentInChildren<WeaponScript>();
			if (weapon != null)
			{
				// False because player is not the enemy
				weapon.Attack(false);
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
	
	void OnDestroy()
	{
		// Game over, go to menu
		Application.LoadLevel(Scenes.MENU);
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