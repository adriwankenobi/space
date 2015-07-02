using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(5, 5);
	private Vector2 movement;
	public Vector2 direction = new Vector2(-1, 0);

	void Update()
	{	
		// Move according to direction
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		
	}

	// Same as Update() but executed for each fixed frame, because phisics
	void FixedUpdate()
	{
		// Apply movement
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
