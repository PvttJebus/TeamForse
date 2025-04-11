using UnityEngine;
using TMPro;

public class TooltipManager3D : MonoBehaviour
{
    public static TooltipManager3D Instance;

    public GameObject tooltipObject;
    public TextMeshProUGUI tooltipText;

    private void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    private void Update()
    {
        if (tooltipObject.activeSelf)
        {
            Vector3 offset = new Vector3(15f, -15f, 0f);
            tooltipObject.transform.position = Input.mousePosition + offset;
        }
    }

    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipObject.SetActive(false);
    }
}
