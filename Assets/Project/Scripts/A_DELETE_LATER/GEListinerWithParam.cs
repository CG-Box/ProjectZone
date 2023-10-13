using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class SenderEvent : UnityEvent<object>
{
}

public class GEListinerWithParam : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GE_Params Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public SenderEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(object sender)
    {
        Response.Invoke(sender);
    }
}