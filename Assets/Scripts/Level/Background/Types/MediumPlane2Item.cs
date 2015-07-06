using UnityEngine;

/* 
 * AutomoveItem for Medium plane 2
*/

public class MediumPlane2Item : AutoMoveItem {
	
	public MediumPlane2Item()
	{
		_Speed = new Vector2(0.5f, 0.5f);
		_Direction = new Vector2(-1, 0);
		_Offset = 12;
	}
	
}