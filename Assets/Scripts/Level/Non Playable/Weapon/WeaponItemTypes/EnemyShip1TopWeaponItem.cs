using UnityEngine;

/* 
 * Weapon for enemy ship #1, top weapon
*/

public class EnemyShip1TopWeaponItem : WeaponItem {
	
	public EnemyShip1TopWeaponItem()
	{
		_TimeToWaitBetweenShots = 2f;
		_InitialTimeToWait = 0;
		_RotationZ = -30;
	}
	
}