using UnityEngine;

public class TooltipTarget3D : MonoBehaviour
{
    [TextArea]
    public string tooltipMessage = "I am a tooltip!";

    void OnMouseEnter()
    {
        TooltipManager3D.Instance.ShowTooltip(tooltipMessage);
    }

    void OnMouseExit()
    {
        TooltipManager3D.Instance.HideTooltip();
    }
}
