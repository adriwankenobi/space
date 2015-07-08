using UnityEngine;

/* 
 * Movement for player ship
*/

public class PlayerShipMoveItem : RigibodyMoveItem {
	
	public PlayerShipMoveItem()
	{
		_Speed = new Vector2(3, 3);
		_Direction = new Vector2(1, 0);
		_Offset = 0;
	}
	
}