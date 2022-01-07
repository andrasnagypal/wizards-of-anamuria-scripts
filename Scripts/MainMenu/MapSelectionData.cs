using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrystalType:byte
{
    Red,
    Green,
    Blue,
    Purple,
    Yellow
}

public static class MapSelectionData
{
    public static CrystalType crystalOfTheGame;
}
