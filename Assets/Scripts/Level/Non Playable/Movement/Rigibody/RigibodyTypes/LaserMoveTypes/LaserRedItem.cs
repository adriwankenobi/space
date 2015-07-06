using UnityEngine;

/* 
 * Movement for red laser
*/

public class LaserRedItem : RigibodyMoveItem {
	
	public LaserRedItem()
	{
		_Speed = new Vector2(5, 5);
		_Direction = new Vector2(-1, 0);
		_Offset = 0;
	}
	
}