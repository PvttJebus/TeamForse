using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventPopupUI : MonoBehaviour
{
    [Header("Attach the ScriptableObject Here (optional)")]
    public GameEventBase assignedEvent;
    public EventManager eventManager;
    // or RandomEvent / DisasterEvent if you want a specific type

    [Header("UI References")]
    public TextMeshProUGUI titleText;      // drag the title TMP from the prefab
    public TextMeshProUGUI descriptionText; // middle panel TMP
    public Button thingAButton;           // for the "Thing A" button
    public TextMeshProUGUI thingAText;    // text on the button
    public Button thingBButton;           // for the "Thing B" button
    public TextMeshProUGUI thingBText;    // text on the button

    // Called automatically if 'assignedEvent' is set in Inspector,
    // or you could call it manually at runtime
    private void Awake()
    {
        if (assignedEvent != null)
        {
            PopulateUI(assignedEvent);
        }
    }

    /// <summary>
    /// Call this method whenever you need to populate the popup 
    /// with a given event’s data (can be assignedEvent or some other event).
    /// </summary>
    public void PopulateUI(GameEventBase gameEvent)
    {
        // Update the text fields
        if (titleText != null)
            titleText.text = gameEvent.eventName;

        if (descriptionText != null)
            descriptionText.text = gameEvent.description;

        // If you have multiple choices, you might read gameEvent.choices[0], etc.
        // Example: show the first two choices on ThingA / ThingB
        if (gameEvent.choices.Count > 0)
        {
            if (thingAButton != null && thingAText != null)
            {
                thingAButton.gameObject.SetActive(true);
                thingAText.text = gameEvent.choices[0].choiceText;
                // Hook up an onClick if needed:
                thingAButton.onClick.RemoveAllListeners();
                thingAButton.onClick.AddListener(() => OnChoiceClicked(gameEvent, 0));
            }
        }

        if (gameEvent.choices.Count > 1)
        {
            if (thingBButton != null && thingBText != null)
            {
                thingBButton.gameObject.SetActive(true);
                thingBText.text = gameEvent.choices[1].choiceText;
                // Hook up an onClick if needed:
                thingBButton.onClick.RemoveAllListeners();
                thingBButton.onClick.AddListener(() => OnChoiceClicked(gameEvent, 1));
            }
        }
    }

    /// <summary>
    /// Example callback for when the player picks a choice.
    /// In a real setup, you'd call your EventManager.OnChoiceSelected() here.
    /// </summary>
    private void OnChoiceClicked(GameEventBase ev, int choiceIndex)
    {
        ev.OnChoiceSelected(choiceIndex);
        Destroy(gameObject);
    }
}
