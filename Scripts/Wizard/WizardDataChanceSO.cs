using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WizadChance", menuName = "ScriptableObjects/WizardDataChance", order = 1)]
public class WizardDataChanceSO : ScriptableObject
{
    public byte Wandering,
    Questing,
    Gathering,
    Examining,
    Visiting,
    Meditating,
    Experimenting,
    Gardening,
    Research,
    Invoking;
}
