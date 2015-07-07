using UnityEngine;

/* 
 * Weapon for player ship
*/

public class PlayerShipWeaponItem : WeaponItem {
	
	public PlayerShipWeaponItem()
	{
		_TimeToWaitBetweenShots = 1f;
		_RotationZ = 0;
	}
	
}