using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  WizardAttributesData 
{
    public int currentHealth, maxHealth, concentration,  spellEnergy,intellect,knowledge;
    public string wizardId;
    public WizardAttributesData()
    {
        currentHealth = 200;
        maxHealth = 200;
        concentration = 0;
        knowledge = 0;
        spellEnergy = 0;
        intellect = 0;
    }
}
