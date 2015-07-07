using UnityEngine;

/* 
 * Health for enemy ship #1
*/

public class EnemyShip1HealthItem : HealthItem {

	public EnemyShip1HealthItem()
	{
		_MaxHealth = 2;
		_Health = _MaxHealth;
		_IsEnemy = true;
	}
	
}