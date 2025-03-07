using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    [Header("Events")]
    public List<RandomEvent> randomEvents;
    public List<DisasterEvent> disasterEvents;

    [Header("UI Popup")]
    public GameObject popupPrefab;

    [Header("Game State Tracking")]
    public int currentTurn;

    public int playerCash;
    public int playerIncome;
    public float totalFatalityRiskReduction;
    public float totalInjuryRiskReduction;
    public int playerActionPoints;
    public int influence;

    private Dictionary<GameEventBase, int> eventChoiceHistory = new Dictionary<GameEventBase, int>();

    /// <summary>
    /// (New) Unified resource update method. 
    /// </summary>
    public void UpdateResources(int cashDelta, int incomeDelta, float fatalityDelta, float injuryDelta, int actionPointsDelta, int influenceDelta)
    {
        // Add the deltas to the fields
        playerCash += cashDelta;
        playerIncome += incomeDelta;
        totalFatalityRiskReduction += fatalityDelta;
        totalInjuryRiskReduction += injuryDelta;
        playerActionPoints += actionPointsDelta;
        influence += influenceDelta;

        // Example: clamp to avoid negative action points
        if (playerActionPoints < 0)
            playerActionPoints = 0;

        // Optional debug
        Debug.Log($"[EventManager] Updated resources => Cash: {playerCash}, Income: {playerIncome}, " +
                  $"FatalityRisk: {totalFatalityRiskReduction}, InjuryRisk: {totalInjuryRiskReduction}, " +
                  $"ActionPoints: {playerActionPoints}, Influence: {influence}");
    }

    // ---------------------------------------------------------
    // The rest of the code remains unchanged except we call UpdateResources
    // in OnChoiceSelected instead of directly incrementing the fields.
    // ---------------------------------------------------------

    public void CheckEventsForTurn(int turnNumber)
    {
        currentTurn = turnNumber;
        Debug.Log($"[EventManager] Checking events for turn {currentTurn}.");

        DisasterEvent triggeredDisaster = CheckForDisaster();
        if (triggeredDisaster != null)
        {
            TriggerEvent(triggeredDisaster);
            return;
        }

        RandomEvent triggeredRandom = GetRandomEvent();
        if (triggeredRandom != null)
        {
            TriggerEvent(triggeredRandom);
        }
    }

    private DisasterEvent CheckForDisaster()
    {
        foreach (var disaster in disasterEvents)
        {
            if (!eventChoiceHistory.ContainsKey(disaster) && disaster.CanTrigger(currentTurn))
                return disaster;
        }
        return null;
    }

    private RandomEvent GetRandomEvent()
    {
        List<RandomEvent> validEvents = new List<RandomEvent>();

        foreach (var rnd in randomEvents)
        {
            if (!eventChoiceHistory.ContainsKey(rnd) && rnd.CanTrigger(currentTurn))
                validEvents.Add(rnd);
        }

        if (validEvents.Count > 0)
        {
            int index = Random.Range(0, validEvents.Count);
            return validEvents[index];
        }
        return null;
    }

    private void TriggerEvent(GameEventBase ev)
    {
        ev.OnEventTriggered();
        eventChoiceHistory[ev] = -1;

        if (popupPrefab != null)
        {
            GameObject popupInstance = Instantiate(popupPrefab, this.transform);
            var popupUI = popupInstance.GetComponent<EventPopupUI>();
            if (popupUI != null)
            {
                popupUI.PopulateUI(ev);
            }
        }
        else
        {
            Debug.LogWarning("[EventManager] No popupPrefab assigned in Inspector!");
        }

        if (ev is DisasterEvent disasterEv && disasterEv.endsTheGame)
        {
            Debug.LogWarning($"[EventManager] DisasterEvent {ev.eventName} ended the game!");
            // Insert end-of-game logic if desired
        }
    }

    public void OnChoiceSelected(GameEventBase ev, int choiceIndex)
    {
        if (!eventChoiceHistory.ContainsKey(ev))
        {
            Debug.LogWarning($"[EventManager] Event not triggered or invalid reference: {ev.eventName}");
            return;
        }
        if (choiceIndex < 0 || choiceIndex >= ev.choices.Count)
        {
            Debug.LogWarning($"[EventManager] Invalid choice index for {ev.eventName}");
            return;
        }

        eventChoiceHistory[ev] = choiceIndex;
        ev.OnChoiceSelected(choiceIndex);

        // Instead of directly applying outcome to each field, 
        // we pass them to UpdateResources:
        ChoiceOutcome outcome = ev.choices[choiceIndex];
        UpdateResources(outcome.cashChange,
                        outcome.incomeChange,
                        outcome.fatalityRiskChange,
                        outcome.injuryRiskChange,
                        -outcome.actionPointCost, // note it's negative cost
                        outcome.influenceChange);

        Debug.Log($"[EventManager] Applied outcome: {outcome.choiceText} from {ev.eventName}.");
    }

    public int GetChoiceForEvent(GameEventBase ev)
    {
        if (eventChoiceHistory.ContainsKey(ev))
            return eventChoiceHistory[ev];
        return -1;
    }
}
