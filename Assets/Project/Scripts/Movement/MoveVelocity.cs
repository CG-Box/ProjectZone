using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveVelocity : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    //[SerializeField]
    private bool allowMoving = true;

	public Vector2 MoveDirection
	{
		get { return velocityVector; }
	}

    Vector3 velocityVector;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public void EnableMoving()
    {
        allowMoving = true;
    }
    public void DisableMoving()
    {
        allowMoving = false;
        velocityVector = Vector3.zero;
    }
    public void SetAllowMoving(bool allowMoving)
    {
        this.allowMoving = allowMoving;
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        if(allowMoving)
            this.velocityVector = velocityVector;
    }

    void FixedUpdate()
    {
        rb2D.velocity = velocityVector * moveSpeed;
        //Play anim
    }
}
