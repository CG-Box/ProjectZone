using System;
using UnityEngine;

[RequireComponent(typeof(MoveVelocity))]
[RequireComponent(typeof(HealthBehaviour))]
public class BaseController: MonoBehaviour
{
	protected MoveVelocity moveVelocity;

    protected HealthBehaviour healthBehaviour;

	public event Action<BaseController> OnDie;

	protected bool isDead = false;
	public bool IsDead
	{
		get { return IsDead; }
	}
	public bool IsAlive
	{
		get { return !IsDead; }
	}

	void Awake()
	{
		moveVelocity = GetComponent<MoveVelocity>();
        healthBehaviour = GetComponent<HealthBehaviour>();
		isDead = false;
	}

    public virtual void Die()
	{
		isDead = true;
		moveVelocity.DisableMoving();
		OnDie?.Invoke(this);
	}
	public virtual void Revive()
	{
		isDead = false;
		moveVelocity.EnableMoving();
	}

    protected void CheckForDeath(float health)
    {
        if(health == 0)
            Die();
    }


}