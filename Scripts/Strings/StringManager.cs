using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StringTypes
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
    Invoking,
    Arcane,
    Destruction,
    Protection,
    Mysticism,
    Conjuring,
    Alchemy,
    DarkMagic,
    Fighting,
    InTransitToTask,
    Stasis,
    HealthPoints,
Concentration,
Intellect,
Knowledge,
Energy,
Lvl,
For,
Turns
}

public class StringManager : MonoBehaviour
{
    [SerializeField] TextAsset textOfStringsForIngameUse;

    string[] stringsToUseInGame;
    public static List<string> stringsListForTheGame = new List<string>();


    private void Awake()
    {
        MakeStringList();
    }

 

    void MakeStringList()
    {
        stringsToUseInGame = textOfStringsForIngameUse.text.Split('\n');
        stringsListForTheGame = new List<string>(stringsToUseInGame);
    }
}
