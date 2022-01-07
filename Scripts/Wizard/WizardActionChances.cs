using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardActionChances 
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
    public WizardActionChances()
    {
        Wandering = 0;
        Questing = 0;
        Gathering = 0;
        Examining = 0;
        Visiting = 0;
        Meditating = 0;
        Experimenting = 0;
        Gardening = 0;
        Research = 0;
        Invoking = 0;
    }
    public WizardActionChances(WizardDataChanceSO data)
    {
        Wandering = data.Wandering;
        Questing = data.Questing;
        Gathering = data.Gathering;
        Examining = data.Examining;
        Visiting = data.Visiting;
        Experimenting = data.Experimenting;
        
        Gardening = data.Gardening;
        Research = data.Research;
        Invoking = data.Invoking;
        Meditating = data.Meditating;
        
    }
}
