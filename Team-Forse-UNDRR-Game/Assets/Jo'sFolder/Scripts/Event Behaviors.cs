using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBehaviors : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
