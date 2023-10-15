using UnityEngine;

public class PlayerController: BaseController
{
	public override void Die()
	{
		base.Die();
		StaticEvents.Combat.OnPlayerDeath?.Invoke();
		gameObject.SetActive(false);
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

	void HappyPlayer(GameObject enemyGameObject)
	{
		Debug.Log($"enemy : {enemyGameObject.name} died");
	}
}