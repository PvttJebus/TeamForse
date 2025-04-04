using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStringManagement : MonoBehaviour
{
    public string endingString;
    public GameObject endPanelPrefab;

    public void AddToEndingString(string input)
    {
        endingString += ($"\n{input}");
    }

    public void EndgamePopup()
    {
        //refs & instantiate end panel
        GameObject endPanelObject = Instantiate( endPanelPrefab, this.transform );
        EventPopupUI endPanelUI = endPanelObject.GetComponent<EventPopupUI>();

        //populate
        if (endPanelUI!= null)
        {
            endPanelUI.titleText.text = ("Game Over!");
            endPanelUI.descriptionText.text = endingString;
            endPanelUI.thingAText.text = ("Continue...");
        }
        else
        {
            Debug.LogWarning("Endgame panel ui component is null!");
        }
    }
}
