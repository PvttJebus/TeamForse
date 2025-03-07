using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMInitialValues : MonoBehaviour
{
    [SerializeField]
    public int funds, income, maxActions, influence, population;
    GameManager gameManager;


    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.AdjustFunds(funds);
        gameManager.AdjustIncome(income);
        gameManager.AdjustMaxPlayerActions(maxActions);
        gameManager.AdjustPoliticalInfluence(influence);
        gameManager.AdjustPopulation(population);
    }
}
