using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject buildingUIPanel;

    [Header("Resource / Metric Deltas")]
    public int cashDelta;
    public int incomeDelta;
    public float fatalityRiskDelta;
    public float injuryRiskDelta;
    public int actionPointsDelta;
    public int influenceDelta;

    [Header("Reference to EventManager")]
    // This references the SAME object that has the resource fields & UpdateResources method
    public EventManager eventManager;

    private void OnMouseDown()
    {
        if (buildingUIPanel != null)
        {
            buildingUIPanel.SetActive(true);
        }
    }

    public void OnBuildingAction()
    {
        if (eventManager != null)
        {
            if (eventManager.playerActionPoints > 0)
            {
                // Use the new unified UpdateResources method
                eventManager.UpdateResources(cashDelta,
                                             incomeDelta,
                                             fatalityRiskDelta,
                                             injuryRiskDelta,
                                             actionPointsDelta,
                                             influenceDelta);

                Debug.Log($"[BuildingInteraction] {name} used. " +
                          $"Cash: {cashDelta}, Income: {incomeDelta}, " +
                          $"FatalityRisk: {fatalityRiskDelta}, InjuryRisk: {injuryRiskDelta}, " +
                          $"ActionPoints: {actionPointsDelta}, Influence: {influenceDelta}");
            }
            else
            {
                //Do popup?
                Debug.Log("No action points! Cannot complete action");
            }
        }
        else
        {
            Debug.LogWarning($"[BuildingInteraction] No EventManager assigned on {name}.");
        }

        if (buildingUIPanel != null)
        {
            buildingUIPanel.SetActive(false);
        }
    }
}
