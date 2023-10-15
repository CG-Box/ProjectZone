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

    bool canShoot = true;
    public bool CanShoot
    {
        get { return canShoot; }
    }

    void Awake()
    {
        if(!shootOrigin)
        {
            Debug.LogWarning("Select correct transform for shootOrigin");
            shootOrigin = transform;
        }
    }

    void OnEnable()
    {
        StaticEvents.Collecting.OnOutOfAmmo += DisableShooting;
        StaticEvents.Collecting.OnItemCollect += CheckForBullets;
    }  
    void OnDisable()
    {
        StaticEvents.Collecting.OnOutOfAmmo -= DisableShooting;
        StaticEvents.Collecting.OnItemCollect -= CheckForBullets;
    }

    void DisableShooting()
    {
        canShoot = false;
    }
    void EnableShooting()
    {
        canShoot = true;
    }

    void CheckForBullets(ItemBase item)
    {
        if(item.type == ItemType.Ammo)
        {
            EnableShooting();
        }
    }

    void ShootBullet()
    {
        // Создаем экземпляр пули
        //GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);
        StaticEvents.Spawning.OnShootBullet?.Invoke(shootOrigin);
        StaticEvents.Collecting.OnItemUse?.Invoke(new ItemBase(ItemType.Ammo,null,true,1), this.gameObject);
    }

    public bool TryShootBullet()
    {
        if(!canShoot)
            return false;

        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRateTime;
            ShootBullet();
            return true;
        }
        return false;
    }
}
