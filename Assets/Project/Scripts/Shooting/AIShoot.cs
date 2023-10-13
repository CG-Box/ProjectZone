using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    [SerializeField]
    ShooterBehaviour shooterBehaviour;

    void Hit()
    {
        StaticEvents.Spawning.OnShootBullet?.Invoke(shooterBehaviour.shootOrigin);
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(Hit), 0, 1);
    }
    void OnDisable()
    {
        CancelInvoke(nameof(Hit));
    }
    
}
