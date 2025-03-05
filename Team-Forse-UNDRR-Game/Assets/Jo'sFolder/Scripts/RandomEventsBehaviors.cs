using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DISASTERSLIST
{
    HURRICANE,
    EARTHQUAKE,
}
public class RandomEventsBehaviors : MonoBehaviour
{

    [Header("Game Objects for Random Events")]
    [SerializeField]
    public List<GameObject> RandomEvents;
    public GameObject[] DisasterEventWarnings;
    public GameObject[] DisasterEventPrefabs;

    [Header("Other Properties")]
    [SerializeField]
    public int earliestDisasterWarningTurn, maxTurnsLimit;
    // privs
    private int turnsCount, turnWarningWasGiven;
    DISASTERSLIST selectedDisaster;
    private bool playerHasBeenWarned;
    public GameObject queuedEvent { get; private set; }

    private void Start()
    {
        playerHasBeenWarned = false;
    }
    public void StartTurn()
    {
        turnsCount++;
    }

    public void SpawnRandomEvent()
    {
        Instantiate(ChooseRandomEvent(), this.transform);
    }
    public void SpawnQueuedEvent()
    {
        if (queuedEvent != null)
        {
            Instantiate(queuedEvent, this.transform);
            ClearEventQueue();
        }
    }

    /// <summary>
    /// generates random event. we add logic for random spawns here.
    /// </summary>
    /// <returns></returns>
    private GameObject ChooseRandomEvent()
    {
        return RandomEvents[Random.Range(0,RandomEvents.Count)];
    }
    private bool ShouldADisasterStrike()
    {
        //we can add randomization logic here, for now it's true
        return true;
    }
    public bool RunDisastersLogic()
    {
        //Disasters
        if (turnWarningWasGiven + 4 <= turnsCount)
        {
            queuedEvent = DisasterEventPrefabs[(int)selectedDisaster];
            return true;
        }

        //Disaster Warnings
        else if (turnsCount == 1)
        {
            if ( (true)) //|| ShouldADisasterStrike() )
            {
                selectedDisaster = SelectRandomDisaster();
                queuedEvent = DisasterEventWarnings[(int)selectedDisaster];
                if (!playerHasBeenWarned)
                {
                    turnWarningWasGiven = turnsCount;
                }
                playerHasBeenWarned = true;
                return true;
            }
        }

        return false;
    }
    public void ClearEventQueue()
    {
        queuedEvent = null;
    }
    private DISASTERSLIST SelectRandomDisaster()
    {
        int randomNum = Random.Range(0, 4);
        // delete post-alpha
        randomNum = 0;
        //
        switch(randomNum){
            case 0:
                return DISASTERSLIST.HURRICANE;
            case 1:
                return DISASTERSLIST.EARTHQUAKE;
        }
        //else
        return DISASTERSLIST.HURRICANE;
    }
}
