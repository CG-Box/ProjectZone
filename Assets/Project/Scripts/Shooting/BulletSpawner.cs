using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    ObjectPool<GameObject> bulletsPool;

    [SerializeField]
    private GameObject bulletPrefab;

    Transform spawnPosition;

    public int ActiveCount;
    public int DisabledCount;

    void OnEnable()
    {
        StaticEvents.Spawning.OnShootBullet += SpawnBullet;
    }
    void OnDisable()
    {
        StaticEvents.Spawning.OnShootBullet -= SpawnBullet;
    }

    void Awake()
    {
        bulletsPool = new ObjectPool<GameObject>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool);
    }

    private void OnTakeBulletFromPool(GameObject bulletObject)
    {
        bulletObject.SetActive(true);
    }
    private void OnReturnBulletToPool(GameObject bulletObject)
    {
        bulletObject.SetActive(false);
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation, gameObject.transform);
        bullet.GetComponent<Bullet>().SetPool(bulletsPool);
        return bullet;
    }

    public void SpawnBullet(Transform spawnPosition)
    {
        this.spawnPosition = spawnPosition;
        GameObject bullet = bulletsPool.Get();

        bullet.transform.position = spawnPosition.position;
        bullet.transform.rotation = spawnPosition.rotation;
        bullet.GetComponent<Bullet>().MoveForward();

        DisabledCount = bulletsPool.CountInactive;
        ActiveCount = bulletsPool.CountActive;
    }

    /*
    void OnEnable()
    {
        InvokeRepeating(nameof(SpawnBullet), 0, 1);
    }
    void OnDisable()
    {
        CancelInvoke(nameof(SpawnBullet));
    }
    */
}
