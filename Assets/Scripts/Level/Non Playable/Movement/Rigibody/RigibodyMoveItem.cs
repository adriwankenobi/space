using UnityEngine;
using System.Collections;

/* 
 * Item to handle movements of rigibodies
*/

public class RigibodyMoveItem : MoveItem {

	public enum Type {
		ENEMY_SHIP_TYPE_1,
		LASER_RED,
		LASER_BLUE
	};

	public static RigibodyMoveItem create(Type type)
	{
		switch (type)
		{
		case Type.ENEMY_SHIP_TYPE_1: 
			return new EnemyShip1MoveItem();
		case Type.LASER_RED: 
			return new LaserRedMoveItem();
		case Type.LASER_BLUE: 
			return new LaserBlueMoveItem();
		default: 
			throw new System.ArgumentException("Incorrect RigibodyMoveItem.Type " + type.ToString());
		}
	}

}
