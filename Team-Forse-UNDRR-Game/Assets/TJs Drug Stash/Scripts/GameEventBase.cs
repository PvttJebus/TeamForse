using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventBase : ScriptableObject
{
    [Header("Basic Info")]
    public string eventName;
    [TextArea] public string description;

    [Header("Choices & Outcomes")]
    // Each event can have 2-3 choices. Designers can add them via the Inspector.
    public List<ChoiceOutcome> choices;

    [Header("Prefab / UI Display")]
    public GameObject eventPrefab; // The pop-up or in-game object to instantiate

    // We might store whether or not this event has triggered, 
    // but typically that's tracked by the manager.
    // public bool hasTriggered;

    // Override in subclasses if needed
    public virtual bool CanTrigger(int currentTurn)
    {
        // By default, always return true (random events might override)
        return true;
    }

    // Called by the manager once the event is actually triggered
    // so you can do any special logic if needed
    public virtual void OnEventTriggered()
    {
        Debug.Log($"Event Triggered: {eventName}");
    }

    // Called when the player picks a choice
    public virtual void OnChoiceSelected(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= choices.Count)
        {
            Debug.LogWarning($"Invalid choice index {choiceIndex} for event {eventName}");
            return;
        }

        Debug.Log($"{eventName} - Choice selected: {choices[choiceIndex].choiceText}");
    }
}
