using System;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float maxHealth = 100;

    public event Action<float> OnHealthChanged;

    public float Health
    {
        get { return health; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
    }

    void Start()
    {
        //HealthToMax();
    }

    void OnEnable()
    {
        StaticEvents.PlayerHealth.OnRestoreHealth += RecoverDamage;
    }  
    void OnDisable()
    {
        StaticEvents.PlayerHealth.OnRestoreHealth -= RecoverDamage;
    }

    public void TakeDamage(float damageAmount)
    {
        float healthBefore = health;
        health -= damageAmount;
        if(health < 0)
        {
            health = 0;
        }

        if(health != healthBefore)
        {
            OnHealthChanged?.Invoke(health);
        }
    }

    public void RecoverDamage(float recoverAmount)
    {
        float healthBefore = health;
        health += recoverAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health != healthBefore)
        {
            OnHealthChanged?.Invoke(health);
        }
    }
    public void RecoverDamage(float recoverAmount, GameObject targetObject)
    {
        if(gameObject == targetObject)
            RecoverDamage(recoverAmount);
    }


    public void SetHealt(float newHealth)
    {
        float healthBefore = health;
        if(newHealth > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health = newHealth;
        }

        if(health != healthBefore)
        {
            OnHealthChanged?.Invoke(health);
        }
    }
    public void HealthToMax()
    {
        health = maxHealth;
        OnHealthChanged?.Invoke(health);
    }
}
