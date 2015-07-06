using UnityEngine;

/* 
 * AutomoveItem for Background plane
*/

public class BackgroundPlaneItem : AutoMoveItem {
	
	public BackgroundPlaneItem()
	{
		_Speed = new Vector2(2, 2);
		_Direction = new Vector2(-1, 0);
		_Offset = 0;
	}
	
}