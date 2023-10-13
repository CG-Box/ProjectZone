using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthChangeTrigger : MonoBehaviour
{
    [field: SerializeField]
    private float Delta = -10f; 

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(this.Delta);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {}
}
