using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Currencies
{
    Funds,
    Income,
    Influence,
    PopAlive,
    PopInjured,
    PopDead,
    PlayerCurrentActions,
    PlayerMaxActions,
}

[System.Serializable]
public struct OutcomeData
{
    public StatToChange[] statsToChange;
}

[System.Serializable]
public struct StatToChange
{
    public Currencies CostCurrencies;
    public int CostValues;
}

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    //should we add attached images, anything else?
    public string EventName, EventText;
    public OutcomeData[] Outcomes;
}
