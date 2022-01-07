using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplanationType:byte
    {
    Wandering,
    Questing,
    Gathering,
    Examining,
    Visiting,
    Meditating,
    Experimenting,
    Gardening,
    Research,
    Invoking
}


public class ExplanationManager : MonoBehaviour
{
    public string[] explanationStrings;


    public string GetExplanation(ExplanationType explanation)
    {
        return explanationStrings[(int)explanation];
    }
}
