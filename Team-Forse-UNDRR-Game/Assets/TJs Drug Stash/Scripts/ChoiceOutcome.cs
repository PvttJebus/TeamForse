using UnityEngine;

[System.Serializable]
public class ChoiceOutcome
{
    public string choiceText;           // The text shown to the player
    public int cashChange;             // e.g. +100 or -50
    public int incomeChange;           // e.g. +5 or -10
    public float fatalityRiskChange;   // e.g. -0.1f => reduce fatality rate by 10%
    public float injuryRiskChange;     // e.g. -0.2f => reduce injury rate by 20%
    public int actionPointCost;        // cost in points/time/energy to choose this
    public int influenceChange;

    // If you’d like a short description of the outcome (optional):
    [TextArea]
    public string outcomeDescription;
    //ending text input
    [Header("Ending Text Input")]
    [TextArea]
    public string endingText;
}
