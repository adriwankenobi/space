using UnityEngine;

/*
 * Space object constants
 */

public class SpaceObjects {

	public const string BACKGROUND_PLANE = "BackgroundPlane";
	public const string PAUSE_MENU = "PauseMenu";
	public const string PLAYER_SHIP = "PlayerShip";

	public static void Hide(Transform transform)
	{
		transform.position = new Vector3(Camera.main.gameObject.transform.position.x + 10,
		                                 Camera.main.gameObject.transform.position.y - 5,
		                                 GameObject.Find(BACKGROUND_PLANE).transform.position.z + 1);
	}
}