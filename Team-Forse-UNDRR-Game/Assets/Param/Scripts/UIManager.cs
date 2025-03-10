using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMeshPro UI elements

public class UIManager : MonoBehaviour
{
    [Header("City Funds UI")]
    public TextMeshProUGUI cityFundsText;

    [Header("Population UI")]
    public TextMeshProUGUI popAliveText;
    public TextMeshProUGUI popInjuredText;
    public TextMeshProUGUI popDeadText;

    [Header("Workforce UI")]
    public TextMeshProUGUI workforceText; // "Available / Total"

    [Header("Player Actions UI")]
    public TextMeshProUGUI actionsText; // "Available / Max"

    [Header("Political Influence UI")]
    public Image politicalInfluencePieChart; // Pie chart fill

    public EventManager eventManager;

    void Start()
    {
        eventManager = FindObjectOfType<EventManager>().GetComponent<EventManager>();
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();  // Call this every frame (or optimize with an event-based approach)
    }

   public void UpdateUI()
    {
        // Update City Funds
        cityFundsText.text = $"{eventManager.playerCash}";

        // Update Population
        popAliveText.text = $"{eventManager.currentPopulation}";
        //popInjuredText.text = $"{eventManager.popInjured}";
        //popDeadText.text = $"{eventManager.popDead}";

        // Update Workforce
        //int totalWorkforce = eventManager.workforceActive + eventManager.workforceIdle;
        //workforceText.text = $"{eventManager.workforceIdle}/{eventManager.workforceTotal}";

        // Update Actions
        actionsText.text = $"{eventManager.playerActionPoints}";

        // Update Political Influence Pie Chart (Normalized)
        float influencePercent = eventManager.influence / 100f;
        politicalInfluencePieChart.fillAmount = influencePercent;
    }
}
