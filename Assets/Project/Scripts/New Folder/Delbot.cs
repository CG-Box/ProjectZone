using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Delbot : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Enemy";

    public RotateOrigin rt;

    CircleCollider2D coll2D;

    void Awake()
    {
        coll2D = GetComponent<CircleCollider2D>();

        SetColliderRadius(lookRadius);

        var visibleRadius = GetColliderRadius();
        Debug.Log(visibleRadius);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            rt.LockTarget(collider.gameObject.transform);
            Debug.Log(collider.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            rt.UnlockTarget();
            Debug.Log(collider.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }

    float GetColliderRadius()
    {
        return transform.localScale.x * coll2D.radius;
    }
    void SetColliderRadius(float radius)
    {
        float rad = GetColliderRadius();
        coll2D.radius = radius / transform.localScale.x;
    }

    public float lookRadius = 10f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
