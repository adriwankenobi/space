using UnityEngine;
using System.Collections;

/* 
 * Item to handle weapons
*/

public class WeaponItem {

	protected float _TimeToWaitBetweenShots;
	protected float _InitialTimeToWait;
	protected int _RotationZ;

	public enum Type {
		PLAYER_WEAPON,
		ENEMY_SHIP_TYPE_1_WEAPON_TOP,
		ENEMY_SHIP_TYPE_1_WEAPON_BOTTOM,
		ENEMY_SHIP_TYPE_1_WEAPON_CENTER
	};
	
	public static WeaponItem create(Type type)
	{
		switch (type)
		{
		case Type.PLAYER_WEAPON: 
			return new PlayerShipWeaponItem();
		case Type.ENEMY_SHIP_TYPE_1_WEAPON_TOP: 
			return new EnemyShip1TopWeaponItem();
		case Type.ENEMY_SHIP_TYPE_1_WEAPON_BOTTOM: 
			return new EnemyShip1BottomWeaponItem();
		case Type.ENEMY_SHIP_TYPE_1_WEAPON_CENTER: 
			return new EnemyShip1CenterWeaponItem();
		default: 
			throw new System.ArgumentException("Incorrect WeaponItem.Type " + type.ToString());
		}
	}

	public float TimeToWaitBetweenShots {
		get {
			return _TimeToWaitBetweenShots;
		}
		set {
			_TimeToWaitBetweenShots = value;
		}
	}

	public float InitialTimeToWait {
		get {
			return _InitialTimeToWait;
		}
		set {
			_InitialTimeToWait = value;
		}
	}

	public int RotationZ {
		get {
			return _RotationZ;
		}
		set {
			_RotationZ = value;
		}
	}
}
