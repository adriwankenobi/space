using UnityEngine;
using System.Collections;

/*
 * Script to handle rigibodies movement
 */

public class RigibodyMovementScript : MonoBehaviour {
	
	public RigibodyMoveItem.Type itemType;

	private RigibodyMoveItem item;
	private Vector2 movement;

	void Awake()
	{
		item = RigibodyMoveItem.create(itemType);
	}

	void Update()
	{	
		// Move according to direction
		movement = new Vector2(
			item.Speed.x * item.Direction.x,
			item.Speed.y * item.Direction.y);
	}

	// Same as Update() but executed for each fixed frame, because phisics
	void FixedUpdate()
	{
		// Apply movement
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	public Vector2 Direction {
		get {
			return item.Direction;
		}
		set {
			item.Direction = value;
		}
	}
}
