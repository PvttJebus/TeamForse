using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForTurnSystemUI : MonoBehaviour
{
    public GameObject startTurnPopup, preTurnPopup, playerActionsGroup, endTurnPopup;
    GameObject[] AttachedGameObjects;
    private void Start()
    {
        AttachedGameObjects = new GameObject[] { startTurnPopup, preTurnPopup, playerActionsGroup, endTurnPopup };
    }
    public void StartTurnPopup()
    {
        startTurnPopup.SetActive(true);
    }

    public void PreActionsPopup()
    {
        preTurnPopup.SetActive(true);
    }

    public void PlayerActionsPhase()
    {
        playerActionsGroup.SetActive(true);
    }

    public void EndTurnPopup()
    {
        endTurnPopup.SetActive(true);
    }
    public void DisableAllObjects()
    {
        foreach (GameObject obj in AttachedGameObjects)
        {
            obj.SetActive(false);
        }
    }
}
