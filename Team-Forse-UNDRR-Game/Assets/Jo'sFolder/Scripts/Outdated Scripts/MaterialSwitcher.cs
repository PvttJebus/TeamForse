using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    [SerializeField]
    public Material material, material2;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material;
    }

    private void OnMouseDown()
    {
        SwapMaterials();
    }

    public void SwapMaterials()
    { 
        rend.sharedMaterial = material2;
        Material tempMat = material;
        material = material2;
        material2 = tempMat;
    }

}