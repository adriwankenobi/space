using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* 
 * Script for background infinite movement
*/

public class AutoMoveScript : MonoBehaviour
{
	public AutoMoveItem.Type itemType;

	private AutoMoveItem item;
	private List<Transform> infiniteObjects;

	void Start()
	{

		item = AutoMoveItem.create(itemType);

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

	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			item.Speed.x * item.Direction.x,
			item.Speed.y * item.Direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate(movement);

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
					firstObject.position = new Vector3(lastPosition.x + lastSize.x + item.Offset, firstObject.position.y, firstObject.position.z);
						
					// Delete the first object and put it back in the new position
					infiniteObjects.Remove(firstObject);
					infiniteObjects.Add(firstObject);
				}
			}
		}
	}
}