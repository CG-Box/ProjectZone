using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DetectTargetsInRange : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Enemy";

    public RotateOrigin rotateOrigin;

    void Awake()
    {}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            rotateOrigin.LockTarget(collider.gameObject.transform);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            rotateOrigin.UnlockTarget();
        }
    }
}
