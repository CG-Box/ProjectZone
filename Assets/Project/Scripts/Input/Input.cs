using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(MoveVelocity))]
public class Input : MonoBehaviour
{
    #region MoveInput
    MoveVelocity moveVelocity;

    void Awake()
    {
        moveVelocity = GetComponent<MoveVelocity>();
    }

	void OnMove(InputValue inputValue)
	{
        moveVelocity.SetVelocity(inputValue.Get<Vector2>());
	}
    #endregion

    #region UseInput
    bool holdUseButton = false;
    
    void OnUse()
    {
        //Released button
        if(holdUseButton)
        {
            StaticEvents.Controls.OnUseReleased?.Invoke();
            holdUseButton = false;
        }
        //Button pressed
        else
        {
            holdUseButton = true;
            StaticEvents.Controls.OnUsePressed?.Invoke();
        }
    }
    
    void Update()
    {
        if(holdUseButton)
        {
            StaticEvents.Controls.OnUseHold?.Invoke();
        }
    }
    #endregion
}
