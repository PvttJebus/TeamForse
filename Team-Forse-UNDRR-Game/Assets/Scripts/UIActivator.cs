using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject[] subPanels;
    private GameObject currentPanel;

    void Start()
    {
        CloseAllPanels();
    }

    // Called when clicking an object to open the main panel
    public void OpenMainPanel()
    {
        mainPanel.SetActive(true);
        currentPanel = mainPanel;
    }

    // Called when clicking a button to switch to a specific panel
    public void SwitchToPanel(GameObject panel)
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        panel.SetActive(true);
        currentPanel = panel;
    }

    // Called when clicking back button to return to main panel
    public void BackToMainPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        mainPanel.SetActive(true);
        currentPanel = mainPanel;
    }

    // Called when clicking back button on main panel to close UI
    public void CloseAllPanels()
    {
        mainPanel.SetActive(false);
        foreach (GameObject panel in subPanels)
        {
            panel.SetActive(false);
        }
        currentPanel = null;
    }
}
