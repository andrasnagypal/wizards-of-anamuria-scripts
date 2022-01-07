using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSetupData 
{
    public int howLongActionWillTake,wizardPortraitVariant;
    public int[] tileWizardIsOn;
    public string wizardName;
   
    public WizardAction currentAction;
    public WizardActionChances chancesForAction, hiddenChancesForActionModifiers;
    public WizardAttributesData dataOfWizardAttributes;
    public WizardCombatData combatData;
    public WizardMovementData dataForMovement;
    public WizardCharacterInfoLvls barInfoLvlsForUI;
    public List<ScrollKnowledge> scrollsTheWizardKnow;
    public GameObject combatTarget;
    public TaskInfoForTheWizard currentTaskInfoForTheWizard;
}
