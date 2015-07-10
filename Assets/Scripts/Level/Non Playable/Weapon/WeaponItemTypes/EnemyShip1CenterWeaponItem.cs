using UnityEngine;

/* 
 * Weapon for enemy ship #1, center weapon
*/

public class EnemyShip1CenterWeaponItem : WeaponItem {
	
	public EnemyShip1CenterWeaponItem()
	{
		_TimeToWaitBetweenShots = 2f;
		_InitialTimeToWait = 0;
		_RotationZ = 0;
	}
	
}