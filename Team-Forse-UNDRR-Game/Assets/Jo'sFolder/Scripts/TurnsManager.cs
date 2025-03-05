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
    public RandomEventsBehaviors eventsMan;
    //Ref to Test UI
    public TestForTurnSystemUI UI;

    private bool isEventQueued;

    private void Start()
    {
        isEventQueued = false;
        StartTurn();
    }

    public void StartTurn()
    {
        state = TurnState.TURNSTART;
        //income
        gameManager.AddIncomeToFunds();
        gameManager.AdjustCurrentPlayerActions(gameManager.maxPlayerActions - gameManager.currentPlayerActions);
        //events queued?
        eventsMan.StartTurn();
        isEventQueued = eventsMan.RunDisastersLogic();
        isEventQueued = true;
        //
        UI.DisableAllObjects();
        UI.StartTurnPopup();
    }

    public void PreActionsPhase()
    {
        state = TurnState.PREACTIONS;
        //check for random/fixed events
        if (eventsMan.queuedEvent != null && isEventQueued)
        {
            eventsMan.SpawnQueuedEvent();
        }
        else if (!isEventQueued)
        {
            eventsMan.SpawnRandomEvent();
        }
        //
        UI.DisableAllObjects();
        UI.PreActionsPopup();
    }

    public void PlayerActionsPhase()
    {
        state = TurnState.PLAYERACTIONS;
        //
        UI.DisableAllObjects();
        UI.PlayerActionsPhase();
        //we can enable things like our "on map" events here. Unity Event?
    }

    public void EndTurn()
    {
        state = TurnState.TURNEND;
        //
        UI.DisableAllObjects();
        UI.EndTurnPopup();
        //do we still want to do all of our resource transactions at end of turn?
        //we can trigger an event here really easily to do both that and our proper end of turn things like a disaster.
    }
}
