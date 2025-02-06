using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selectable : MonoBehaviour
{
    public GameObject menuToSpawn;

    //public MenuManager menuManager;
    public bool isSelected;

    private void OnMouseDown()
    {
        isSelected = true;
        Instantiate(menuToSpawn);
        //menuManager.selectedObject = this;
    }

    public void Unselect()
    {
        isSelected = false;
        //menuManager.selectedObject = null;
    }
}
