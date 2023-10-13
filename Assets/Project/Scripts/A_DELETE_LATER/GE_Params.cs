using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GE_Params", menuName = "SriptableObjects/GameEvent_With_Params")]
public class GE_Params : ScriptableObject
{

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif


    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GEListinerWithParam> eventListeners = 
        new List<GEListinerWithParam>();

	//HashSet<GameEventListener> eventListeners = new HashSet<GameEventListener>();

    public void Raise(object sender)
    {
        for(int i = eventListeners.Count -1; i >= 0; i--)
            eventListeners[i].OnEventRaised(sender);

	//foreach (var eventListeners in eventListeners)
	//	eventListeners.OnEventRaised(); 
    }

    public void RegisterListener(GEListinerWithParam listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GEListinerWithParam listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}