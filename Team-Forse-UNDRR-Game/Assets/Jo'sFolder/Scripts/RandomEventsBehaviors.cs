using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventsBehaviors : MonoBehaviour
{
    public GameObject[] RandomEvents;

    public void SpawnRandomEvent()
    {
        Instantiate(GenerateRandomEvent(), this.transform);
    }

    /// <summary>
    /// generates random event. we add logic for random spawns here.
    /// </summary>
    /// <returns></returns>
    private GameObject GenerateRandomEvent()
    {
        return RandomEvents[Random.Range(0,RandomEvents.Length)];
    }
}
