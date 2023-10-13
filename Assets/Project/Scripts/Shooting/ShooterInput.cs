using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterBehaviour))]
public class ShooterInput : MonoBehaviour
{
    ShooterBehaviour shooterBehaviour;

    void Awake()
    {
        shooterBehaviour = GetComponent<ShooterBehaviour>();
    }

    void OnEnable()
    {
        StaticEvents.Controls.OnUseHold += Shoot;
    }
    void OnDisable()
    {
        StaticEvents.Controls.OnUseHold -= Shoot;
    }

    void Shoot()
    {
        shooterBehaviour.TryShootBullet();
    }
}
