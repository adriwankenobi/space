using UnityEngine;
using System.Collections;

/*
 * Behaviour of playable ship
 */

public class PlayerShipScript : MonoBehaviour {

	private int speed = 3;

	private bool dragging;
	private int clickId;
	private Vector3 originalShipPosition;
	private Vector3 lastClickPosition;
	private Vector3 targetPosition;

	void Update()
	{
		// Get pauseScript from components
		PauseScript pauseSript = GameObject.Find(SpaceObjects.PAUSE_MENU).GetComponent<PauseScript>();

		// If game not paused
		if (!pauseSript.isPaused) {

			InputExtensions.InputResult clickDown = InputExtensions.IsClickedDown();
			if (clickDown.Input)
			{
				dragging = true;
				clickId = clickDown.InputId;
				lastClickPosition = Camera.main.ScreenToWorldPoint(clickDown.Position);
				lastClickPosition = new Vector3(lastClickPosition.x,
				                                lastClickPosition.y,
				                           		transform.position.z);
				originalShipPosition = transform.position;

			}

			InputExtensions.InputResult click = InputExtensions.IsClicked();
			if (dragging && click.Input && clickId == click.InputId)
			{
				// Set target to defined position (difference since current and last clicked, referenced from player ship position)
				Vector3 currentTargetPosition = Camera.main.ScreenToWorldPoint(click.Position);
				targetPosition = new Vector3(originalShipPosition.x + currentTargetPosition.x - lastClickPosition.x,
				                             originalShipPosition.y + currentTargetPosition.y - lastClickPosition.y,
				                             transform.position.z);
			}

			InputExtensions.InputResult clickUp = InputExtensions.IsClickedUp();
			if (dragging && clickUp.Input && clickId == clickUp.InputId)
			{
				dragging = false;
				clickId = InputExtensions.InputResult.INIT_ID;
			}
			
			// Verify ship is not outside from camera -> limit borders of the camera
			adjustBordersCamera(transform);
		}
	}

	void FixedUpdate()
	{
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		if (dragging)
		{
			rigidbody2D.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed));
		} 
		else
		{
			rigidbody2D.velocity = Vector2.zero;
		}
	}

	private void adjustBordersCamera(Transform transform)
	{
		float distance = (transform.position - Camera.main.transform.position).z;
		
		float leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, distance)
			).x;
		
		float rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, distance)
			).x;
		
		float topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, distance)
			).y;
		
		float bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, distance)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}
	
	void OnDestroy()
	{
		// Game over, go to menu
		Application.LoadLevel(Scenes.MENU);
	}

}