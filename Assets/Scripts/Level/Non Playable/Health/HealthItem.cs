using UnityEngine;
using System.Collections;

/* 
 * Item to handle health
*/

public class HealthItem {

	protected int _Health;
	protected int _MaxHealth;
	protected bool _IsEnemy;

	public enum Type {
		PLAYER_SHIP,
		ENEMY_SHIP_TYPE_1
	};
	
	public static HealthItem create(Type type)
	{
		switch (type)
		{
		case Type.PLAYER_SHIP: 
			return new PlayerShipHealthItem();
		case Type.ENEMY_SHIP_TYPE_1: 
			return new EnemyShip1HealthItem();
		default: 
			throw new System.ArgumentException("Incorrect HealthItem.Type " + type.ToString());
		}
	}

	public int Health {
		get {
			return _Health;
		}
		set {
			_Health = value;
		}
	}

	public int MaxHealth {
		get {
			return _MaxHealth;
		}
		set {
			_MaxHealth = value;
		}
	}

	public bool IsEnemy {
		get {
			return _IsEnemy;
		}
		set {
			_IsEnemy = value;
		}
	}

}
