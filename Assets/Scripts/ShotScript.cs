using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of shot
/// </summary>
public class ShotScript : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemyShot = false;
	
	void Start()
	{
		// Shot object should dissapear after some time
		Destroy(gameObject, 10); // 10 seconds
	}
}