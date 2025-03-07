using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject[] subPanels;
    public GameObject defaultCanvas; // The canvas to disable when opening the main panel
    private GameObject currentPanel;

    void Start()
    {
        CloseAllPanels();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Mouse Click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ClickableObject")) // Tag your object as "ClickableObject"
                {
                    OpenMainPanel();
                }
            }
        }
    }

    public void OpenMainPanel()
    {
        if (defaultCanvas != null)
        {
            defaultCanvas.SetActive(false); // Disable the default canvas
        }
        mainPanel.SetActive(true);
        currentPanel = mainPanel;
    }

    public void SwitchToPanel(GameObject panel)
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        panel.SetActive(true);
        currentPanel = panel;
    }

    public void BackToMainPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        mainPanel.SetActive(true);
        currentPanel = mainPanel;
    }

    public void CloseAllPanels()
    {
        mainPanel.SetActive(false);
        foreach (GameObject panel in subPanels)
        {
            panel.SetActive(false);
        }
        currentPanel = null;

        if (defaultCanvas != null)
        {
            defaultCanvas.SetActive(true); // Re-enable the default canvas when all panels are closed
        }
    }
}
