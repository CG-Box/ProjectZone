public class EnemyController: BaseController
{
	public override void Die()
	{
		base.Die();
        StaticEvents.Combat.OnEnemyDeath?.Invoke(this.gameObject);
		gameObject.SetActive(false);
	}
	public override void Revive()
	{
		base.Revive();
	}

    void OnEnable()
	{
        healthBehaviour.OnHealthChanged += CheckForDeath;
	}
	void OnDisable()
	{
        healthBehaviour.OnHealthChanged -= CheckForDeath;
	}
}