using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "SriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif


    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListener> eventListeners = 
        new List<GameEventListener>();

	//HashSet<GameEventListener> eventListeners = new HashSet<GameEventListener>();

    public void Raise()
    {
        for(int i = eventListeners.Count -1; i >= 0; i--)
            eventListeners[i].OnEventRaised();

	//foreach (var eventListeners in eventListeners)
	//	eventListeners.OnEventRaised(); 
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}