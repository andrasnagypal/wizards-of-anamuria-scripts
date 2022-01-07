using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BuildingInfo", menuName = "ScriptableObjects/BuildingInfo", order = 3)]
public class BuildingInfoSO : ScriptableObject
{
    public BuildingType building;
    public string description;
    public int cost;
    public Sprite artForButton;
}
