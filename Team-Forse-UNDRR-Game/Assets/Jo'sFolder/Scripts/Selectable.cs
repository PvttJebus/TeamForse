using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selectable : MonoBehaviour
{
    public GameObject menuToSpawn;
    public Vector3 cameraOffset;
    //public MenuManager menuManager;
    public bool isSelected;

    public Vector3 GetSelectionCameraPosition()
    {
        return gameObject.transform.position + cameraOffset;
    }
    public void Select()
    {
        isSelected = true;
        //menuToSpawn.SetActive(true);
    }

    public void Unselect()
    {
        isSelected = false;
    }
}
