using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLink : MonoBehaviour, IPointerClickHandler
{
    [Header("Link URL")]
    public string url = "https://www.undrr.org/";  // Add your desired URL here

    /// <summary>
    /// Open the URL when the button is clicked.
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        OpenLink();
    }

    private void OpenLink()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("No URL set for this button.");
        }
    }
}
