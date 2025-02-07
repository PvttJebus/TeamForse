using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Clickable : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Assign in Inspector
    [SerializeField] private Image image; // Assign in Inspector
    [SerializeField] private Button backButton; // Assign in Inspector

    void Start()
    {
        if (backButton != null)
        {
            backButton.gameObject.SetActive(false); // Hide button initially
            backButton.onClick.AddListener(CloseUI); // Add event listener
        }
    }

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

        if (backButton != null)
        {
            backButton.gameObject.SetActive(true); // Show Back Button
        }
    }

    void CloseUI()
    {
        if (panel != null) panel.SetActive(false);
        if (image != null) image.gameObject.SetActive(false);
        if (backButton != null) backButton.gameObject.SetActive(false);

        Debug.Log("UI Closed!");
    }
}
