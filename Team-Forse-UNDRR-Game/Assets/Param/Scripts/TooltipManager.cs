using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipObject;
    public TextMeshProUGUI tooltipText;

    void Update()
    {
        if (tooltipObject.activeSelf)
        {
            tooltipObject.transform.position = Input.mousePosition;
        }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        tooltipObject.SetActive(false);
    }

    public void ShowTooltip(string message, Vector3 position)
    {
        tooltipText.text = message;

        // Add an offset to avoid overlap with the cursor
        Vector3 offset = new Vector3(10f, -10f, 0f);
        tooltipObject.transform.position = position + offset;

        tooltipObject.SetActive(true);
    }


    public void HideTooltip()
    {
        tooltipObject.SetActive(false);
    }
}
