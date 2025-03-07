using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRandomEvent", menuName = "Events/RandomEvent")]
public class RandomEvent : GameEventBase
{
    [Header("Random Event Turn Range")]
    public int minTurn;
    public int maxTurn;

    public override bool CanTrigger(int currentTurn)
    {
        // Random event triggers if the current turn is within [minTurn, maxTurn]
        return (currentTurn >= minTurn && currentTurn <= maxTurn);
    }
}

