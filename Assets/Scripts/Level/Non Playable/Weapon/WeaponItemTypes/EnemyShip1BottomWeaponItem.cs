using UnityEngine;

/* 
 * Weapon for enemy ship #1, bottom weapon
*/

public class EnemyShip1BottomWeaponItem : WeaponItem {
	
	public EnemyShip1BottomWeaponItem()
	{
		_TimeToWaitBetweenShots = 2f;
		_InitialTimeToWait = 0;
		_RotationZ = 30;
	}
	
}