using UnityEngine;

/* 
 * Movement for blue laser
*/

public class LaserBlueItem : RigibodyMoveItem {
	
	public LaserBlueItem()
	{
		_Speed = new Vector2(5, 5);
		_Direction = new Vector2(1, 0);
		_Offset = 0;
	}
	
}