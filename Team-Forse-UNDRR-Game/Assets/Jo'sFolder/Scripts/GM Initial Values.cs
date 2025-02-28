using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMInitialValues : MonoBehaviour
{
    [SerializeField]
    public int funds, maxActions, influence, population;
    GameManager gameManager;


    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.AdjustFunds(funds);
        gameManager.AdjustMaxPlayerActions(maxActions);
        gameManager.AdjustPoliticalInfluence(influence);
        gameManager.AdjustPopulation(population);
    }
}
