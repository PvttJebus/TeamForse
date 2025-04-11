using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStringManagement : MonoBehaviour
{
    public string endingString;
    public GameObject endPanelPrefab;
    public EventManager eventManager;

    private void Awake()
    {
        eventManager = GetComponent<EventManager>();
    }

    public void AddToEndingString(string input)
    {
        endingString += ($"{input}\n\n");
    }

    public void EndgamePopup()
    {
        //refs & instantiate end panel
        GameObject endPanelObject = Instantiate( endPanelPrefab, this.transform );
        EventPopupUI endPanelUI = endPanelObject.GetComponent<EventPopupUI>();

        float currentPop = eventManager.currentPopulation;
        float deadPop = currentPop - (currentPop * eventManager.totalFatalityRiskReduction);
        float injuredPop = currentPop - (currentPop * eventManager.totalInjuryRiskReduction);

        //populate
        if (endPanelUI!= null)
        {
            endPanelUI.titleText.text = ("Game Over!");
            endPanelUI.descriptionText.text = ($"{endingString} + In the disaster, {deadPop} people died, and {injuredPop} people were injured.");
            endPanelUI.thingAText.text = ("Continue...");
        }
        else
        {
            Debug.LogWarning("Endgame panel ui component is null!");
        }
    }
}
