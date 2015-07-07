using UnityEngine;
using System.Collections;

/*
 * Behaviour of laser
 */
public class LaserScript : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemyShot = false;

	void Update()
	{
		if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
		{
			Destroy(gameObject);
		}
	}
}