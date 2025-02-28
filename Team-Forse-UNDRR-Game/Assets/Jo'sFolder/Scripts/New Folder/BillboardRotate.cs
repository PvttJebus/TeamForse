using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardRotate : MonoBehaviour
{
    public Transform targetToLookAt, objectToRotate;
    public float rotateSpeed;

    private void FixedUpdate()
    {
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetToLookAt.rotation, rotateSpeed*Time.deltaTime);
    }
}
