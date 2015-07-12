using UnityEngine;

/*
 * Input utils
 */

public static class InputExtensions
{

	private enum Phase {
		BEGAN,
		MOVED,
		ENDED
	};

	private static bool GetInput(GameObject gameObject, Phase phase)
	{
		#if UNITY_ANDROID

		if (Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch currentTouch = Input.GetTouch(i);

				if (gameObject == null || IsObjectInPosition(gameObject, currentTouch.position))
				{
					switch (phase)
					{
					case Phase.BEGAN: 
						return currentTouch.phase == TouchPhase.Began;
					case Phase.MOVED: 
						return currentTouch.phase == TouchPhase.Moved;
					case Phase.ENDED: 
						return currentTouch.phase == TouchPhase.Ended;
					default: 
						throw new System.ArgumentException("Incorrect InputExtensions.Phase " + phase.ToString());
					}
				}
			}
		}

		return false;

		#endif

		#if UNITY_WEBPLAYER || UNITY_EDITOR
		
		if (gameObject == null || IsObjectInPosition(gameObject, Input.mousePosition))
		{
			switch (phase)
			{
			case Phase.BEGAN: 
				return Input.GetMouseButtonDown(0);
			case Phase.MOVED: 
				return Input.GetMouseButton(0);
			case Phase.ENDED: 
				return Input.GetMouseButtonUp(0);
			default: 
				throw new System.ArgumentException("Incorrect InputExtensions.Phase " + phase.ToString());
			}
		}
		
		return false;
		
		#endif
	}

	public static Vector3 GetPosition()
	{
		#if UNITY_ANDROID
		
		if (Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch currentTouch = Input.GetTouch(i);
				return currentTouch.position;
			}
		}
		
		#endif
		
		#if UNITY_WEBPLAYER || UNITY_EDITOR
		
		return Input.mousePosition;
		
		#endif
	}

	private static bool IsObjectInPosition(GameObject gameObject, Vector3 position)
	{
		// Cast a ray from input position 
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

		// Hit object is the game object?
		return hit.collider != null && hit.collider.gameObject == gameObject;

	}

	public static bool IsObjectClickedDown(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.BEGAN);
	}

	public static bool IsClickedDown()
	{
		return GetInput(null, Phase.BEGAN);
	}

	public static bool IsObjectClicked(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.MOVED);
	}

	public static bool IsClicked()
	{
		return GetInput(null, Phase.MOVED);
	}

	public static bool IsObjectClickedUp(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.ENDED);
	}

	public static bool IsClickedUp()
	{
		return GetInput(null, Phase.ENDED);
	}
}