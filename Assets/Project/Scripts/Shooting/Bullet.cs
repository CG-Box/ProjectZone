using UnityEngine;
using System.Collections;
using UnityEngine.Pool;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IDamager
{
    [SerializeField]
    private float damage = 10f;
    public float Damage 
    {
        get { return damage; }
    }

    [SerializeField]
    private float moveSpeed = 30f;
    Rigidbody2D rb2D;

    [SerializeField]
    float autoDestroyTime = 5f;
    IEnumerator destroyCoroutine;
    IObjectPool<GameObject> bulletsPool;

    TrailRenderer trailRenderer;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
        if (TryGetComponent<TrailRenderer>(out TrailRenderer trail))
        {
            trailRenderer = trail;
        }
    }

    void Start()
    {
        MoveForward();
    }

    void OnEnable() 
    {
        destroyCoroutine = DestroySelfAfterSeconds(autoDestroyTime);
        StartCoroutine(destroyCoroutine);
    }
    void OnDisable()
    {
        StopCoroutine(destroyCoroutine);

        trailRenderer?.Clear();
    }

    public void MoveForward()
    {
        rb2D.velocity = transform.right * moveSpeed;
    }
    public void StopMoving()
    {
        rb2D.velocity = Vector2.zero;
    }

    IEnumerator DestroySelfAfterSeconds(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        DestroyBullet();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(this.damage);
        }
        DestroyBullet();
    }

    public void SetPool(IObjectPool<GameObject> objectPool)
    {
        this.bulletsPool = objectPool;
    }

    void DestroyBullet()
    {
        StopCoroutine(destroyCoroutine);

        if(bulletsPool != null)
        {
            bulletsPool.Release(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
