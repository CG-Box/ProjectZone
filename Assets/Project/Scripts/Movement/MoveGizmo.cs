using UnityEngine;
using UnityEngine.InputSystem;

public class MoveGizmo : MonoBehaviour
{
	Vector2 moveDirection = Vector2.zero;
	Vector2 lookDirection = Vector2.right;

	public Vector2 MoveDirection
	{
		get { return moveDirection; }
	}
	public Vector2 LookDirection
	{
		get { return lookDirection; }
	}

    void OnMove(InputValue inputValue)
	{
		moveDirection = inputValue.Get < Vector2 > ();

		bool isMoving = !moveDirection.Equals(Vector2.zero);
		if (isMoving)
			lookDirection = moveDirection;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 targetPosition = transform.position + ( Vector3 )lookDirection;
        Gizmos.DrawLine(transform.position, targetPosition);

        //Debug.DrawLine(transform.position, transform.position + ( Vector3 )lookDirection, Color.white, 0.5f);
    }
}
