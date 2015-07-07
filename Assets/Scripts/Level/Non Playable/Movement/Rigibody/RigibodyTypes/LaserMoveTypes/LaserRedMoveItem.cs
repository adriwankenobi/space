using UnityEngine;

/* 
 * Movement for red laser
*/

public class LaserRedMoveItem : RigibodyMoveItem {
	
	public LaserRedMoveItem()
	{
		_Speed = new Vector2(5, 5);
		_Direction = new Vector2(-1, 0);
		_Offset = 0;
	}
	
}