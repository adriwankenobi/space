using UnityEngine;

/* 
 * AutomoveItem for Medium plane 1
*/

public class MediumPlane1Item : AutoMoveItem {
	
	public MediumPlane1Item()
	{
		_Speed = new Vector2(1, 1);
		_Direction = new Vector2(-1, 0);
		_Offset = 1;
	}
	
}