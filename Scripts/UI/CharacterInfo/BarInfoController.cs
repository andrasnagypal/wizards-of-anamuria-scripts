using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BarInfoType:byte
{
    Wandering,
    Questing,
    GatherMushrooms,
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
    HP,
    Concentration,
    Intellect, 
    Knowledge,
    Energy
}

public class BarInfoController : MonoBehaviour
{
    public TextMeshProUGUI description, info,buttonInfo;
   
    
    public BarInfoType typeOfBar;  

    public void PlayerLvledUpThis()
    {

        FindObjectOfType<CharacterInfoController>().PlayerChoseThis(typeOfBar);
    }
    public void ShowInfo()
    {

    }
    public void StopShowingInfo()
    {

    }
}
