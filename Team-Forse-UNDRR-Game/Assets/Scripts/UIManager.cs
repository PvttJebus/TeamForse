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

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();  // Call this every frame (or optimize with an event-based approach)
    }

   public void UpdateUI()
    {
        // Update City Funds
        cityFundsText.text = $"Funds: ${gameManager.cityFunds:F2}";

        // Update Population
        popAliveText.text = $"Alive: {gameManager.popAlive}";
        popInjuredText.text = $"Injured: {gameManager.popInjured}";
        popDeadText.text = $"Dead: {gameManager.popDead}";

        // Update Workforce
        int totalWorkforce = gameManager.workforceActive + gameManager.workforceIdle;
        workforceText.text = $"Workforce: {gameManager.workforceIdle}/{gameManager.workforceTotal}";

        // Update Actions
        actionsText.text = $"Actions: {gameManager.currentPlayerActions}/{gameManager.maxPlayerActions}";

        // Update Political Influence Pie Chart (Normalized)
        float influencePercent = gameManager.PoliticalInfluence / 100f;
        politicalInfluencePieChart.fillAmount = influencePercent;
    }
}
