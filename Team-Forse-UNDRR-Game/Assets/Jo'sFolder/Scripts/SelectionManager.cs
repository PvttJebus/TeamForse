using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    public GameObject hovering { get; private set; }
    public GameObject selected { get; private set; }

    //
    private RaycastHit raycastHit;
    private void Update()
    {
        //updates Ray for casting
        Ray mousePointRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Raycasts here. Ensure Eventsystem is in scene!
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(mousePointRay, out raycastHit))
        {
            hovering = raycastHit.transform.gameObject;
            if (hovering.CompareTag("SelectableMesh") && hovering != selected)
            {
                //Hovering Behaviors here!
            }
        }
        else
        {
            hovering = null;
        }

        if(Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (selected != null)
            {
                selected = null;
            }
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(mousePointRay, out raycastHit))
            {
                selected = raycastHit.transform.gameObject;
                if (selected.CompareTag("SelectableMesh"))
                {
                    //Selection Behaviors here!
                }
                else
                {
                    selected = null;
                }
            }
        }

    }
}
