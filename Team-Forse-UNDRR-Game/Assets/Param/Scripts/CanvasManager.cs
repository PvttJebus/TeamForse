using UnityEngine;

public class DefaultCanvasManager : MonoBehaviour
{
    private Canvas defaultCanvas;

    // Array of panels that won't deactivate the default canvas (exceptions)
    public GameObject[] exceptionPanels;

    private void Start()
    {
        // Get the reference to the canvas this script is attached to
        defaultCanvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        bool nonExceptionPanelActive = false;

        // Find all panels in the scene
        GameObject[] allPanels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (GameObject panel in allPanels)
        {
            // Skip exceptions
            if (panel.activeSelf && !IsException(panel))
            {
                nonExceptionPanelActive = true;
                break;
            }
        }

        // Disable default canvas if any non-exception panel is active
        // Reactivate it when all panels are closed
        defaultCanvas.gameObject.SetActive(!nonExceptionPanelActive);
    }

    // Check if the panel is in the exception list
    private bool IsException(GameObject panel)
    {
        foreach (GameObject exception in exceptionPanels)
        {
            if (panel == exception)
            {
                return true;
            }
        }
        return false;
    }
}
