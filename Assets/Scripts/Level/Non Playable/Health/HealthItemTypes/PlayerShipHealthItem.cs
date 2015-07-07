using UnityEngine;

/* 
 * Health for player ship
*/

public class PlayerShipHealthItem : HealthItem {
	
	public PlayerShipHealthItem()
	{
		_MaxHealth = 5;
		_Health = _MaxHealth;
		_IsEnemy = false;
	}
	
}