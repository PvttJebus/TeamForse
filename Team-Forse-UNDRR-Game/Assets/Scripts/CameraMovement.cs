using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Transform[] cameraPositions; // Array of camera positions
    public int defaultPositionIndex = 0; // Index of the default camera position
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera

        // Set the camera to the default position if valid
        if (cameraPositions.Length > 0 && defaultPositionIndex < cameraPositions.Length)
        {
            SetCameraPosition(defaultPositionIndex);
        }
        else
        {
            Debug.LogWarning("No camera positions assigned or invalid default index.");
        }
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Cast a ray from the camera to the mouse position
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                CameraPositionTrigger trigger = hit.collider.GetComponent<CameraPositionTrigger>(); // Get the CameraPositionTrigger component

                // If the object has a CameraPositionTrigger, switch to the assigned position
                if (trigger != null)
                {
                    SetCameraPosition(trigger.positionIndex);
                }
            }
        }
    }

    // Method to set the camera position and rotation based on the index
    public void SetCameraPosition(int index)
    {
        if (index >= 0 && index < cameraPositions.Length)
        {
            mainCamera.transform.position = cameraPositions[index].position;
            mainCamera.transform.rotation = cameraPositions[index].rotation;
        }
    }
}