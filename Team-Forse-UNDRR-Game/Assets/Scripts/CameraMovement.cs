using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Smoothing")]
    [SerializeField]
    public float smoothingSpeed;
    [Header("Camera")]
    public Vector3 defaultCameraPosition;
    public Vector3 defaultCameraRotation;
    Vector3 cameraTargetPosition, cameraTargetRotationEuler;
    Selectable currentSelection;
    Camera mainCamera; 

    void Start()
    {
        mainCamera = Camera.main; 
        //these are currently camera default, we can change base position here as well.
        cameraTargetPosition = defaultCameraPosition;
        cameraTargetRotationEuler = defaultCameraRotation;
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
        Vector3 smoothedRotation = Vector3.Lerp(cameraTargetRotationEuler, mainCamera.transform.eulerAngles, smoothingSpeed);
        mainCamera.gameObject.transform.eulerAngles = smoothedRotation;
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
                if (currentSelection != selectable)
                {
                    if (currentSelection != null)
                    {
                        currentSelection.Unselect();
                    }
                    currentSelection = selectable;
                    currentSelection.Select();
                    SetTargetToSelectable(currentSelection);
                }
            }
            else
            {
                SetTargetToDefault();
            }

            //var eventData = new PointerEventData(EventSystem.current);
            //eventData.position = Input.mousePosition;
            //var results = new List<RaycastResult>();
            //EventSystem.current.RaycastAll(eventData, results);
            //if (results.Where(r => r.gameObject.layer == 6).Count() > 0) //6 being my UILayer
            //{
            //    Debug.Log(results[0].gameObject.name); //The UI Element
            //}
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
        cameraTargetRotationEuler = selectable.GetSelectionCameraEuler();
        print($"Camera Target Rotation: {cameraTargetRotationEuler}");
    }

    private void SetTargetToDefault()
    {
        cameraTargetPosition = defaultCameraPosition;
        cameraTargetRotationEuler = defaultCameraRotation;
        if (currentSelection != null)
        {
            currentSelection.Unselect();
            currentSelection = null;
        }
    }

}