using UnityEngine;
using System.Collections;

/* 
 * Item to handle movements
*/

public class MoveItem {

	protected Vector2 _Speed;
	protected Vector2 _Direction;
	protected int _Offset;

	public Vector2 Speed {
		get {
			return _Speed;
		}
		set {
			_Speed = value;
		}
	}

	public Vector2 Direction {
		get {
			return _Direction;
		}
		set {
			_Direction = value;
		}
	}

	public int Offset {
		get {
			return _Offset;
		}
		set {
			_Offset = value;
		}
	}
}
