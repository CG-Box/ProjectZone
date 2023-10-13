using UnityEngine;

public class EnemyController: BaseController
{
	public override void Die()
	{
		base.Die();
        StaticEvents.Combat.OnEnemyDeath?.Invoke(this);
	}
	public override void Revive()
	{
		base.Revive();
	}

    void OnEnable()
	{
        healthBehaviour.OnHealthChanged += CheckForDeath;
		StaticEvents.Combat.OnPlayerDeath += HappyPlayer;
	}
	void OnDisable()
	{
        healthBehaviour.OnHealthChanged -= CheckForDeath;
		StaticEvents.Combat.OnPlayerDeath -= HappyPlayer;
	}

    void HappyPlayer(string str)
	{
		Debug.Log($"player : {str} died");
	}
}