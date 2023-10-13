using System;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float maxHealth = 100;

    public event Action<float> OnHealthChanged;
    public event Action<float> OnMaxHealthChanged;

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
        HealthToMax();
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
    public void RecoverDamage(float reoverAmount)
    {
        float healthBefore = health;
        health += reoverAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
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
