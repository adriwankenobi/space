using UnityEngine;
using System.Collections;

/* 
 * Item to handle auto movements
*/

public class AutoMoveItem : MoveItem {

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
			throw new System.ArgumentException("Incorrect AutoMoveItem.Type " + type.ToString());
		}
	}

}
