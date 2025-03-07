using UnityEngine;
using UnityEngine.UI;
using System;

// Example of the turn states your game cycles through
public enum TurnState { TURNSTART, PREACTIONS, PLAYERACTIONS, TURNEND };

public class PlayerTurnsManager : MonoBehaviour
{
    // Current state of the turn
    public TurnState state { get; private set; }

    // Reference to EventManager (assign in Inspector)
    [Header("Managers & References")]
    public EventManager eventManager;

    // If you have a GameManager that tracks resources, action points, etc.
    public GameManager gameManager;

    // This is the official turn counter for the game
    [Header("Turn Tracking")]
    public int currentTurn;

    // UI Buttons for each phase (drag your button GameObjects in the Inspector)
    [Header("UI Buttons for Each Phase")]
    public GameObject turnStartButton;
    public GameObject preActionsButton;
    public GameObject playerActionsButton;
    public GameObject endTurnButton;

    private void Start()
    {
        // Initialize turn count
        currentTurn = 0;
        // Begin the first turn
        StartTurn();
    }

    // Called when a new turn begins
    public void StartTurn()
    {
        // Increment the turn count here (ONE place only!)
        currentTurn++;

        // Move to TURNSTART state
        state = TurnState.TURNSTART;

        // If you have a GameManager that handles resources/actions, do that logic here
        if (gameManager != null)
        {
            // Example: add income
            gameManager.AddIncomeToFunds();

            // Example: refill action points
            int actionsNeeded = gameManager.maxPlayerActions - gameManager.currentPlayerActions;
            gameManager.AdjustCurrentPlayerActions(actionsNeeded);
        }

        // Update the EventManager with the *latest* turn number (no increments in EventManager).
        // The EventManager can check events for this turn.
        if (eventManager != null)
        {
            eventManager.CheckEventsForTurn(currentTurn);
        }

        // Show/hide the correct buttons for the current phase
        UpdatePhaseButtons();

        Debug.Log("[TurnsManager] Starting turn " + currentTurn + " (TURNSTART)");
    }

    // Phase 1: Pre-actions phase
    public void PreActionsPhase()
    {
        state = TurnState.PREACTIONS;
        UpdatePhaseButtons();
        Debug.Log("[TurnsManager] PreActionsPhase started.");
    }

    // Phase 2: Player actions phase
    public void PlayerActionsPhase()
    {
        state = TurnState.PLAYERACTIONS;
        UpdatePhaseButtons();
        Debug.Log("[TurnsManager] PlayerActionsPhase started.");
    }

    // Phase 3: End of turn
    public void EndTurn()
    {
        state = TurnState.TURNEND;
        UpdatePhaseButtons();
        Debug.Log("[TurnsManager] EndTurn phase started.");
    }

    // Called by UI buttons to advance to the next phase
    public void GoToNextPhase()
    {
        switch (state)
        {
            case TurnState.TURNSTART:
                // Move to PREACTIONS
                PreActionsPhase();
                break;

            case TurnState.PREACTIONS:
                // Move to PLAYERACTIONS
                PlayerActionsPhase();
                break;

            case TurnState.PLAYERACTIONS:
                // Move to TURNEND
                EndTurn();
                break;

            case TurnState.TURNEND:
                // Cycle back to a new Turn
                StartTurn();
                break;
        }
    }

    // Hides all phase buttons except the one for the current phase
    private void UpdatePhaseButtons()
    {
        if (turnStartButton != null)
            turnStartButton.SetActive(state == TurnState.TURNSTART);

        if (preActionsButton != null)
            preActionsButton.SetActive(state == TurnState.PREACTIONS);

        if (playerActionsButton != null)
            playerActionsButton.SetActive(state == TurnState.PLAYERACTIONS);

        if (endTurnButton != null)
            endTurnButton.SetActive(state == TurnState.TURNEND);
    }
}
