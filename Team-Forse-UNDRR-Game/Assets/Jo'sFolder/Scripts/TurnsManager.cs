using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState { TURNSTART, PREACTIONS, PLAYERACTIONS, TURNEND };
public class TurnsManager : MonoBehaviour
{
    public TurnState state { get; private set; }
    public GameManager gameManager; //{ get; private set; }
    //event manager ref goes here
    //Ref to Test UI
    public TestForTurnSystemUI UI;
    private void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        state = TurnState.TURNSTART;
        gameManager.AddIncomeToFunds();
        UI.DisableAllObjects();
        UI.StartTurnPopup();
    }

    public void PreActionsPhase()
    {
        state = TurnState.PREACTIONS;
        UI.DisableAllObjects();
        UI.PreActionsPopup();
        //check for random/fixed events
        //if(DoingEvent) {} else
        //playerActionsEnabled
    }

    public void PlayerActionsPhase()
    {
        state = TurnState.PLAYERACTIONS;
        UI.DisableAllObjects();
        UI.PlayerActionsPhase();
        //we can enable things like our "on map" events here. Unity Event?
    }

    public void EndTurn()
    {
        state = TurnState.TURNEND;
        UI.DisableAllObjects();
        UI.EndTurnPopup();
        //do we still want to do all of our resource transactions at end of turn?
        //we can trigger an event here really easily to do both that and our proper end of turn things like a disaster.
    }
}
