using UnityEngine;
using System.Collections;

/* 
 * Helper item for AutoMoveScript
*/

public class AutoMoveItem {

	protected Vector2 _Speed;
	protected Vector2 _Direction;
	protected int _Offset;

	public enum Type {
		BACKGROUND_PLANE, 
		MEDIUM_PLANE_1, 
		MEDIUM_PLANE_2, 
		MEDIUM_PLANE_3,
		MEDIUM_PLANE_4
	};

	public static AutoMoveItem create(Type type)
	{
		switch (type)
		{
		case Type.BACKGROUND_PLANE: 
			return new BackgroundPlaneItem();
		case Type.MEDIUM_PLANE_1: 
			return new MediumPlane1Item();
		case Type.MEDIUM_PLANE_2: 
			return new MediumPlane2Item();
		case Type.MEDIUM_PLANE_3: 
			return new MediumPlane3Item();
		case Type.MEDIUM_PLANE_4: 
			return new MediumPlane4Item();
		default: 
			throw new System.ArgumentException ("Incorrect AutoMoveItem.Type " + type.ToString ());
		}
	}

	public Vector2 Speed {
		get {
			return _Speed;
		}
		protected set {
			_Speed = value;
		}
	}

	public Vector2 Direction {
		get {
			return _Direction;
		}
		protected set {
			_Direction = value;
		}
	}

	public int Offset {
		get {
			return _Offset;
		}
		protected set {
			_Offset = value;
		}
	}
}
