using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Smoothing")]
    [SerializeField]
    public float smoothingSpeed;
    [Header("Camera")]
    public Vector3 defaultCameraPosition;
    Vector3 cameraTargetPosition;
    Selectable currentSelection;
    Camera mainCamera; 

    void Start()
    {
        mainCamera = Camera.main; 
        cameraTargetPosition = mainCamera.transform.position;
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastToTrigger();
        }
        SmoothCameraMovement();
    }

    private void SmoothCameraMovement()
    {
        Vector3 smoothedPosition = Vector3.Lerp(cameraTargetPosition, mainCamera.transform.position, smoothingSpeed);
        mainCamera.gameObject.transform.position = smoothedPosition;
    }

    private void RaycastToTrigger()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Cast a ray from the camera to the mouse position
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //Did we hit a Selectable Object?
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable != null)
            {
                currentSelection = selectable;
                currentSelection.Select();
                SetTargetToSelectable(currentSelection);
            }
            else
            {
                SetTargetToDefault();
            }
        }
        //if we didn't hit any objects, we deselect & set target to default
        else
        {
            SetTargetToDefault();
        }
    }

    private void SetTargetToSelectable(Selectable selectable)
    {
        cameraTargetPosition = selectable.GetSelectionCameraPosition();
        print($"Camera Target Position: {cameraTargetPosition}");

        //do rotation too don't just leave this comment
    }

    private void SetTargetToDefault()
    {
        cameraTargetPosition = defaultCameraPosition;
        currentSelection.Unselect();
        currentSelection = null;
    }

}