using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthChangeTrigger : MonoBehaviour
{
    [field: SerializeField]
    private float Delta = -10f; 

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(this.Delta);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {}


    void OnTriggerExit2D(Collider2D collider) 
    {}
}
