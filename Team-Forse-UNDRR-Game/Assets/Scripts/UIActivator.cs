using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Clickable : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Assign in Inspector
    [SerializeField] private Image image; // Assign in Inspector

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " was clicked!");

        if (panel != null)
        {
            panel.SetActive(true);
            Debug.Log("Panel Activated!");
        }
        else
        {
            Debug.LogError("Panel is NOT assigned in the Inspector!");
        }

        if (image != null)
        {
            image.gameObject.SetActive(true);
            Debug.Log("Image Activated!");
        }
        else
        {
            Debug.LogError("Image is NOT assigned in the Inspector!");
        }
    }
}
