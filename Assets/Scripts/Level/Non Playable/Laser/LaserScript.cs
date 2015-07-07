using UnityEngine;
using System.Collections;

/*
 * Behaviour of laser
 */
public class LaserScript : MonoBehaviour
{
	public LaserItem.Type itemType;
	
	private LaserItem item;
	private bool isEnemy;
	
	void Awake()
	{
		item = LaserItem.create(itemType);
	}

	void Update()
	{
		if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
		{
			Destroy(gameObject);
		}
	}

	public int Damage {
		get {
			return item.Damage;
		}
	}

	public bool IsEnemy {
		get {
			return isEnemy;
		}
		set {
			isEnemy = value;
		}
	}
}