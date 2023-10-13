using UnityEngine;
using System.Collections;

public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // Ссылка на префаб пули

    [SerializeField]
    public Transform shootOrigin;

    float fireRateTime = 0.25f;
    float nextFireTime = 0;

    void Awake()
    {
        if(!shootOrigin)
        {
            Debug.LogWarning("Select correct transform for shootOrigin");
            shootOrigin = transform;
        }
    }

    void ShootBullet()
    {
        // Создаем экземпляр пули
        //GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);
        StaticEvents.Spawning.OnShootBullet?.Invoke(shootOrigin);
    }

    public bool TryShootBullet()
    {
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRateTime;
            ShootBullet();
            return true;
        }
        return false;
    }
}
