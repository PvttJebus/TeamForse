using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TestForTurnSystemUI : MonoBehaviour
{
    GameManager gameManager;
    public GameObject startTurnPopup, preTurnPopup, playerActionsGroup, endTurnPopup, cubesParent;
    GameObject[] AttachedGameObjects;
    public TextMeshProUGUI actionsNum, fundsNum, influenceNum, healthyPopNum;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        AttachedGameObjects = new GameObject[] { startTurnPopup, preTurnPopup, playerActionsGroup, endTurnPopup, cubesParent };
    }
    public void StartTurnPopup()
    {
        startTurnPopup.SetActive(true);
    }

    public void PreActionsPopup()
    {
        preTurnPopup.SetActive(true);
        UpdateAllTexts();
    }

    public void PlayerActionsPhase()
    {
        playerActionsGroup.SetActive(true);

        //all selectables.enable selectable
        cubesParent.SetActive(true);
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

    private void UpdateAllTexts()
    {
        actionsNum.text = gameManager.currentPlayerActions.ToString();
        fundsNum.text = gameManager.cityFunds.ToString();
        influenceNum.text = gameManager.PoliticalInfluence.ToString();
        healthyPopNum.text = gameManager.popAlive.ToString();
    }

    public void ThingA()
    {
        if (gameManager.currentPlayerActions > 0)
        {
            gameManager.AdjustFunds(500);
            gameManager.AdjustCurrentPlayerActions(-1);
        }
        UpdateAllTexts();
    }

    public void ThingB()
    {
        if (gameManager.currentPlayerActions > 0)
        {
            gameManager.AdjustFunds(-500);
            gameManager.AdjustPoliticalInfluence(10);
            gameManager.AdjustCurrentPlayerActions(-1);
        }
        UpdateAllTexts();
    }
}
