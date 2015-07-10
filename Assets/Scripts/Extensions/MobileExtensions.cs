using UnityEngine;

/*
 * Mobile utils
 */

public static class MobileExtensions
{

	#if UNITY_ANDROID

	// Delegates an action
	public delegate void Action();

	// Exceutes some action when the game object is touched
	public static void WhenTouched(GameObject gameObject, Action someAction)
	{
		if (Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch currentTouch = Input.GetTouch(i);
				if (currentTouch.phase == TouchPhase.Began)
				{
					string gameObjectColliderName = gameObject.GetComponent<Collider2D>().name;
					RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((currentTouch.position)), Vector2.zero);

					if (hit.collider != null && hit.collider.name.Equals(gameObjectColliderName))
					{
						someAction();
					}
				}
			}
		}
	}

	#endif
}