using UnityEngine;
using System.Collections;

/* 
 * Item to handle lasers
*/

public class LaserItem {

	protected int _Damage;

	public enum Type {
		LASER_RED,
		LASER_BLUE
	};
	
	public static LaserItem create(Type type)
	{
		switch (type)
		{
		case Type.LASER_RED: 
			return new LaserRedItem();
		case Type.LASER_BLUE: 
			return new LaserBlueItem();
		default: 
			throw new System.ArgumentException("Incorrect LaserItem.Type " + type.ToString());
		}
	}

	public int Damage {
		get {
			return _Damage;
		}
		set {
			_Damage = value;
		}
	}

}
