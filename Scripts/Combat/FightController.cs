using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FightState:byte
{
    Started,
    WizardsWon,
    CreaturesWon
}
public class FightController : MonoBehaviour
{
    public CombatData dataForFight=new CombatData();
    public GameObject battleAlerter;



    public void CheckAndAddCreatureToFight(CreatureController creature)
    {
        bool isAlreadyOnTile = false;
        foreach (CreatureController item in dataForFight.creaturesInCombat)
        {
            if(item.dataForTheCreature.createId==creature.dataForTheCreature.createId)
            {
                isAlreadyOnTile = true;
                break;
            }
        }
        if (!isAlreadyOnTile)
            dataForFight.creaturesInCombat.Add(creature);
    }
    public void CheckAndAddWizardToFight(WizardController wizard)
    {
        bool isAlreadyOnTile = false;
        foreach (WizardController item in dataForFight.wizardsInCombat)
        {
            if (item.dataForWizard.dataOfWizardAttributes.wizardId == wizard.dataForWizard.dataOfWizardAttributes.wizardId)
            {
                
                isAlreadyOnTile = true;
                break;
            }
        }
        if (!isAlreadyOnTile)
        { 
            dataForFight.wizardsInCombat.Add(wizard);
            FindObjectOfType<UI_PopUpManager>().AddNewPopUp(PopUpType.Combat, wizard.gameObject);
        }
    }

    public void CheckForAFight()
    {
        if(dataForFight.wizardsInCombat.Count>0&&dataForFight.creaturesInCombat.Count>0)
        {
            //FIGHT!
            AddEnemyToCreatures();
            AddEnemyToWizards();
            TurnManager.TurnTick += IsFightOver;
        }
    }

    private void AddEnemyToWizards()
    {
        foreach (WizardController item in dataForFight.wizardsInCombat)
        {
            if (item.dataForWizard.combatTarget == null || item.dataForWizard.combatTarget.GetComponent<CreatureController>().dataForTheCreature.currentHealth <= 0)
            {
                Debug.Log("Creature null check " +dataForFight.creaturesInCombat.Count);
                item.dataForWizard.combatTarget = dataForFight.creaturesInCombat[dataForFight.creaturesInCombat.Count - 1].gameObject;
                item.SetupAction(WizardAction.Fighting);
            }
        }
    }

    public void AddEnemyToCreatures()
    {
        foreach (CreatureController item in dataForFight.creaturesInCombat)
        {
            if (item.dataForTheCreature.targetToAttack == null|| item.dataForTheCreature.targetToAttack.GetComponent<WizardController>().dataForWizard.dataOfWizardAttributes.currentHealth<=0)
            {
                Debug.Log("Wizard null check " + dataForFight.wizardsInCombat.Count);
                item.AttackTarget(dataForFight.wizardsInCombat[dataForFight.wizardsInCombat.Count-1].gameObject);

            }
        }
    }

    public void IsFightOver()
    {
        CheckCreaturesHPAndDetermineTheirDeath();
        CheckWizardsHPAndDetermineTheirDeath();
        if(dataForFight.creaturesInCombat.Count==0||dataForFight.wizardsInCombat.Count==0)
        {
            if(dataForFight.creaturesInCombat.Count>0)
            {
                MakeCreaturesIdle();
            }
            Debug.Log("IsFightOver");
            if (dataForFight.wizardsInCombat.Count > 0)
            {
                MakeWizardsContinueThereTasks();
            }
        }
       
    }

    private void MakeWizardsContinueThereTasks()
    {
        TurnManager.TurnTick -= IsFightOver;
        foreach (WizardController item in dataForFight.wizardsInCombat)
        {
            item.FightOver();
            
        }
        dataForFight.wizardsInCombat.Clear();
        //Remove CombatAlerter
        
    }

    private void MakeCreaturesIdle()
    {
        foreach (CreatureController item in dataForFight.creaturesInCombat)
        {
            item.combatController.StopFighting();
            item.dataForTheCreature.targetToAttack = null;
            item.animationController.SetIdlingAnimationForCreature(item.TheCreature);
        }
    }

    private void CheckWizardsHPAndDetermineTheirDeath()
    {
        WizardController diedWizard = null;
        foreach (WizardController item in dataForFight.wizardsInCombat)
        {
            if (item.dataForWizard.dataOfWizardAttributes.currentHealth <= 0)
            {
                diedWizard = item;
                break;
            }
        }
        if (diedWizard != null)
        {
            dataForFight.wizardsInCombat.Remove(diedWizard);
            RemoveWizardFromGettingTargetedByCreatures(diedWizard);
            if(dataForFight.wizardsInCombat.Count>0)
            AddEnemyToCreatures();
            MakeWizardDie(diedWizard);
        }
    }

    private void MakeWizardDie(WizardController diedWizard)
    {
        GameObject deathCircle =FindObjectOfType<CombatArenaManager>(). poolForDeathCircle.GetDeathCircle();
        deathCircle.transform.position = diedWizard.gameObject.transform.position;
        deathCircle.GetComponent<DeathCircleController>().dataForWizard = diedWizard.dataForWizard;
        diedWizard.FightOver();
    }

    private void RemoveWizardFromGettingTargetedByCreatures(WizardController diedWizard)
    {
        foreach (CreatureController item in dataForFight.creaturesInCombat)
        {
            if (item.dataForTheCreature.targetToAttack != null || item.dataForTheCreature.targetToAttack.GetComponent<WizardController>().dataForWizard.dataOfWizardAttributes.wizardId==diedWizard.dataForWizard.dataOfWizardAttributes.wizardId)
            {

                item.dataForTheCreature.targetToAttack = null;

            }
        }
    }

    private void CheckCreaturesHPAndDetermineTheirDeath()
    {
        CreatureController diedCreature = null;
        foreach (CreatureController item in dataForFight.creaturesInCombat)
        {
            if (item.dataForTheCreature.currentHealth <=0)
            {
                diedCreature = item;
                break;
            }
        }
        if(diedCreature!=null)
        {
            dataForFight.creaturesInCombat.Remove(diedCreature);
            RemoveCreatureFromGettingTargetedByWizards(diedCreature);
            if (dataForFight.creaturesInCombat.Count > 0)
                AddEnemyToWizards();
            MakeCreatureDie(diedCreature);
        }
    }

    private void MakeCreatureDie(CreatureController diedCreature)
    {
        diedCreature.combatController.StopFighting();
        diedCreature.SetDying();
    }

    private void RemoveCreatureFromGettingTargetedByWizards(CreatureController diedCreature)
    {
        foreach (WizardController item in dataForFight.wizardsInCombat)
        {
            if (item.dataForWizard.combatTarget != null || item.dataForWizard.combatTarget.GetComponent<CreatureController>().dataForTheCreature.createId==diedCreature.dataForTheCreature.createId)
            {
                item.dataForWizard.combatTarget = null;
              
            }
        }
    }
}
