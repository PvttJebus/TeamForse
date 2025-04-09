using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClickCube : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MaterialSwitcher materialSwitcher;
    private void Awake()
    {
        materialSwitcher = GetComponent<MaterialSwitcher>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        materialSwitcher.SwapMaterials();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        materialSwitcher.SwapMaterials();
    }
}
