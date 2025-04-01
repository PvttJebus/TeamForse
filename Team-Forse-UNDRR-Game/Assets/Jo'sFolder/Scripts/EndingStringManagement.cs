using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStringManagement : MonoBehaviour
{
    public string endingString;

    public void AddToEndingString(string input)
    {
        endingString += ($"\n{input}");
    }

    public string GetEndingString()
    {
        return endingString;
    }
}
