public class EnemyController: BaseController
{
	public bool ControlledByPool = false;
	public override void Die()
	{
		base.Die();
        StaticEvents.Combat.OnEnemyDeath?.Invoke(this.gameObject);

		if(!ControlledByPool)
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