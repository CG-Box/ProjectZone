using UnityEngine;
using UnityEngine.InputSystem;

public class Log : MonoBehaviour
{

    MoveVelocity moveVelocity;

    void Start()
    {
        PlayerController myObject = FindObjectOfType<PlayerController>();
        moveVelocity = myObject.GetComponent<MoveVelocity>();
    }

    // Update is called once per frame
    void OnMove(InputValue inputValue)
    {
        Debug.Log($"inputValue {inputValue.Get<Vector2>().x}");
                moveVelocity.SetVelocity(inputValue.Get<Vector2>());
    }

    void OnFire()
    {
        Debug.Log("OnFire");
    }
}
