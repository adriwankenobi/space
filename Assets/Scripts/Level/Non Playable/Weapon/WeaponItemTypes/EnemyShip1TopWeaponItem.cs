using UnityEngine;

/* 
 * Weapon for enemy ship #1, top weapon
*/

public class EnemyShip1TopWeaponItem : WeaponItem {
	
	public EnemyShip1TopWeaponItem()
	{
		_TimeToWaitBetweenShots = 2f;
		_RotationZ = -30;
	}
	
}