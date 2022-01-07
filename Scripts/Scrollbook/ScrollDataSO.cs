using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScrollData", menuName = "ScriptableObjects/ScrollData", order = 3)]
public class ScrollDataSO :ScriptableObject
{
    public ScrollType scroll;
    public string nameOfScroll,description,scrollParameters;
    public int scrollAmountAllTogether,scrollCostForThePlayer;
    public Sprite artForScroll;
}
