using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDisasterEvent", menuName = "Events/DisasterEvent")]
public class DisasterEvent : GameEventBase
{
    [Header("Disaster Properties")]
    public bool endsTheGame;
    // You might have a required turn or condition for when the disaster triggers
    public int disasterTurn;

    public override bool CanTrigger(int currentTurn)
    {
        // For example, can only trigger on or after a certain turn
        return (currentTurn >= disasterTurn);
    }

    public override void OnEventTriggered()
    {
        base.OnEventTriggered();
        if (endsTheGame)
        {
            Debug.Log($"DISASTER: {eventName} triggered. This ends the game!");
        }
    }
    public override void OnChoiceSelected(int choiceIndex)
    {
        base.OnChoiceSelected(choiceIndex);
        if (endsTheGame)
        {
            EndingStringManagement endstringRef = FindObjectOfType<EndingStringManagement>().GetComponent<EndingStringManagement>();
            endstringRef.EndgamePopup();
        }
            
    }
}
