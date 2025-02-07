using UnityEngine;
using UnityEngine.UI;

public class EventChoice : MonoBehaviour
{
    public GameObject eventPanel; // Assign the event panel in the Inspector
    public Button helpButton;
    public Button ignoreButton;

    private bool eventActive = false;

    private void Start()
    {
        // Assign button functions
        helpButton.onClick.AddListener(CloseEventPanel);
        ignoreButton.onClick.AddListener(CloseEventPanel);

        // Ensure event panel is hidden initially
        eventPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !eventActive)
        {
            ShowEventPanel();
        }
    }

    private void ShowEventPanel()
    {
        eventPanel.SetActive(true);
        eventActive = true;
    }

    private void CloseEventPanel()
    {
        eventPanel.SetActive(false);
        eventActive = false;
    }
}
