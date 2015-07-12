using UnityEngine;

/*
 * Space object constants
 */

public class SpaceObjects {

	public const string BACKGROUND_PLANE = "BackgroundPlane";
	public const string BUTTONS_PLANE = "ButtonsPlane";
	public const string PAUSE_MENU = "PauseMenu";
	public const string PLAYER_SHIP = "PlayerShip";

	public static void Hide(Transform transform)
	{
		transform.position = new Vector3(transform.position.x,
		                                 transform.position.y,
		                                 GameObject.Find(BACKGROUND_PLANE).transform.position.z + 1);
	}
}