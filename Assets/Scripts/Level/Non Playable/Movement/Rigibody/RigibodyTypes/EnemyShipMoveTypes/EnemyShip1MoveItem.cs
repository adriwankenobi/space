using UnityEngine;

/* 
 * Movement for enemy ship #1
*/

public class EnemyShip1MoveItem : RigibodyMoveItem {
	
	public EnemyShip1MoveItem()
	{
		_Speed = new Vector2(2, 2);
		_Direction = new Vector2(-1, 0);
		_Offset = 0;
	}
	
}