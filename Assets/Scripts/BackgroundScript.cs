using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Script for background infinite movement
/// </summary>

public class BackgroundScript : MonoBehaviour 
{

	public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(-1, 0);
	public bool isInCamera = false;
	public bool isInfinite = false;
	public int distance = 0;
	private List<Transform> infiniteObjects;
	
	// Let's get all rendered objects
	void Start()
	{
		// If it's infinite -> infinite background
		if (isInfinite)
		{
			// Let's get all child objects
			infiniteObjects = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				
				// Add only the visible children
				if (child.GetComponent<Renderer>() != null)
				{
					infiniteObjects.Add(child);
				}
			}
			
			// Sort by position, t from left to right
			infiniteObjects = infiniteObjects.OrderBy(
				t => t.position.x
				).ToList();
		}
	}

	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);

		// Move the camera
		if (isInCamera)
		{
			Camera.main.transform.Translate(movement);
		}

		// Infinite
		if (isInfinite)
		{
			// Let's get the first object from the left
			Transform firstObject = infiniteObjects.FirstOrDefault();
			
			if (firstObject != null)
			{
				// Check if object is outside the camera
				// WARNING: IsVisibleFrom is heavy
				if (firstObject.position.x < Camera.main.transform.position.x)
				{
					// If object is outside the camera
					if (firstObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
					{
						// Get position of last object
						Transform lastObject = infiniteObjects.LastOrDefault();
						Vector3 lastPosition = lastObject.transform.position;
						Vector3 lastSize = (lastObject.GetComponent<Renderer>().bounds.max - lastObject.GetComponent<Renderer>().bounds.min);
						
						// Put it after the last one
						// WARNING: This only works with horizontal movement
						firstObject.position = new Vector3(lastPosition.x + lastSize.x + distance, firstObject.position.y, firstObject.position.z);
						
						// Delete the first object and put it back in the new position
						infiniteObjects.Remove(firstObject);
						infiniteObjects.Add(firstObject);
					}
				}
			}
		}
	}
}