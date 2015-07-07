using UnityEngine;

/* 
 * Movement for blue laser
*/

public class LaserBlueMoveItem : RigibodyMoveItem {
	
	public LaserBlueMoveItem()
	{
		_Speed = new Vector2(5, 5);
		_Direction = new Vector2(1, 0);
		_Offset = 0;
	}
	
}