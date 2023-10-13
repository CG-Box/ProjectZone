using System;
using UnityEngine;

public class BaseController: MonoBehaviour
{
	protected MoveVelocity moveVelocity;

    protected HealthBehaviour healthBehaviour;

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