using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selectable : MonoBehaviour
{
    public GameObject menuToSpawn;
    //THESE ARE PUBLIC SO THEY CAN BE EASILY SET IN SCENE. USE FUNCTIONS FOR SUPPLEMENTAL SCRIPTS AT RUNTIME.
    public Vector3 cameraOffset, cameraOffsetEuler;
    public bool isSelected {  get; private set; }

    public Vector3 GetSelectionCameraPosition()
    {
        return gameObject.transform.position + cameraOffset;
    }
    public Vector3 GetSelectionCameraEuler()
    {
        return cameraOffsetEuler;
    }
    public void Select()
    {
        isSelected = true;
        if (menuToSpawn != null)
        {
            menuToSpawn.SetActive(true);
        }
    }

    public void Unselect()
    {
        isSelected = false;
        if (menuToSpawn != null)
        {
            menuToSpawn.SetActive(false);
        }
    }
}
