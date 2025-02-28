using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * Hi. Jo here.
     * 
     * This is a big ass GameManager script. I'd personally call it a "CurrencyManager" or "ResourceManager" if I had my pick, but this is chill.
     * 
     *      CONTENTS:
     * Public Properties
     * Private Set Properties
     * Private Properties
     * 
     * Awake (Creates Instance)
     * Money Setters
     * Population Related Setters
     * Workforce Related Setters
     * Action Related Setters
     * 
     * THIS SCRIPT HAS A LOT OF COMMENTS. ALL FUNCTIONS HAVE PROPER SUMMARIES AND DESCRIPTIONS. READ SUMMARIES WHEN USING SCRIPTS.
     */ 


    //This makes a refrence to our GameManager, so we can make it a DontDestroyOnLoad
    private static GameManager instance;

    //Public Properties.
    //This should only contain variables we set in our scene view, like references to other managers attached to other GameObjects.
    [SerializeField]
    [Header("GM Properties")]
    public int theresAVariableHere;

    //Private Set Properties.
    //These are the properties we change during the game. Public functions have been added to adjust all these properties while the game is running.
    public float cityFunds {get; private set;}
    public float cityIncome { get; private set; }
    public int popAlive { get; private set; }
    public int popInjured { get; private set; }
    public int popDead { get; private set; }
    public int workforceTotal { get; private set; }
    public int workforceActive { get; private set; }
    public int workforceIdle { get; private set; }
    public int currentPlayerActions { get; private set; }
    public int maxPlayerActions { get; private set; }
    public int PoliticalInfluence { get; private set; }

    // Awake runs before Start
    private void Awake()
    {
        //This If/Else creates our instance, and makes our Gameobject a DontDestroyOnLoad, we can take it between scenes this way.
        if (instance != null) //only runs if we would have multiple GameManagers, leaving only the original.
        { 
            Destroy(gameObject);
        }
        else //This code makes our GameManager a DontDestroyOnLoad object, and our instance is filled.
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

                            //Fund Related Functions
    /// <summary>
    /// Add Float directly to Funds. Can be used with negative to subtract.
    /// </summary>
    public void AdjustFunds(float amount)
    {
        cityFunds += amount;
    }

    /// <summary>
    /// Add Float directly to Income. Can be used with negative to subtract.
    /// </summary>
    public void AdjustIncome(float amount)
    {
        cityIncome += amount;
    }

    /// <summary>
    /// Every time we income, call this. Calls AdjustFunds(cityIncome), but even easier.
    /// </summary>
    public void AddIncomeToFunds()
    {
        AdjustFunds(cityIncome);
    }




                            //Population Related Functions


    /// <summary>
    /// Add Int directly to popAlive. Can be used with negative to subtract.
    /// </summary>
    public void AdjustPopulation(int amount)
    {
        popAlive += amount;
    }

    /// <summary>
    /// Takes from popAlive and adds to popInjured. 
    /// <summary>
    public void AdjustInjured(int amount)
    {
        AdjustPopulation(-amount);
        popInjured += amount;
    }

    /// <summary>
    /// Takes from popAlive and adds to popDead. Can be used with negative to subtract, for whatever reason, I guess.
    /// </summary>
    public void AdjustDead(int amount)
    {
        AdjustPopulation(-amount);
        popDead += amount;
    }





                            //Workforce Related Functions

    /// <summary>
    /// Add Int directly to workforceIdle. 
    /// </summary>
    public void AdjustWorkforceIdle(int amount)
    {
        workforceIdle += amount;
    }

    /// <summary>
    /// Takes from workforceIdle and adds to workforceActive. Can be used with negative to subtract.
    /// <summary>
    public void AdjustWorkForceActive(int amount)
    {
        AdjustWorkforceIdle(-amount);
        workforceActive += amount;
    }

    /// <summary>
    /// Sends all active workers to Idle.
    /// <summary>
    public void ResetAllWorkers()
    {
        AdjustWorkforceIdle(workforceActive);
        workforceActive = 0;
    }





                            //Fund Related Functions

    /// <summary>
    /// Add Int directly to currentPlayerActions
    /// <summary>
    public void AdjustCurrentPlayerActions(int amount)
    {
        currentPlayerActions += amount;
    }

    /// <summary>
    /// Add Int directly to currentPlayerActions
    /// <summary>
    public void AdjustMaxPlayerActions(int amount)
    {
        maxPlayerActions += amount;
    }

    /// <summary>
    /// Sets current actions to max actions.
    /// <summary>
    public void ResetPlayerActions()
    {
        currentPlayerActions = maxPlayerActions;
    }

    
    /// Adjusts Political Influence. Can be used with negative to subtract.
    /// Clamped between 0 and 100.
    public void AdjustPoliticalInfluence(int amount)
    {
        PoliticalInfluence = Mathf.Clamp(PoliticalInfluence + amount, -100, 100);
    }

}
