using UnityEngine;

public class PlayerController: BaseController
{
	public override void Die()
	{
		base.Die();
		StaticEvents.Combat.OnPlayerDeath?.Invoke(gameObject.name);
	}
	public override void Revive()
	{
		base.Revive();
	}

	void OnEnable()
	{
		healthBehaviour.OnHealthChanged += CheckForDeath;
		StaticEvents.Combat.OnEnemyDeath += HappyPlayer;
	}
	void OnDisable()
	{
		healthBehaviour.OnHealthChanged -= CheckForDeath;
		StaticEvents.Combat.OnEnemyDeath -= HappyPlayer;
	}

	void HappyPlayer(EnemyController enemyController)
	{
		Debug.Log($"enemy : {enemyController.gameObject.name} died");
	}
}