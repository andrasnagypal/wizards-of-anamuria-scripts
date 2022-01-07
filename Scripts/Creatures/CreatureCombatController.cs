using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCombatController : MonoBehaviour
{
    CreatureController creatureController;
    WizardCombatController wizard;
    int meleeAttackSpeed, meleeCounter = 0;
    


    public void StartAttacking()
    {
        if(creatureController==null)
            creatureController = GetComponent<CreatureController>();
        meleeAttackSpeed = (int)creatureController.dataForTheCreature.attackSpeed * 100;
        meleeCounter = meleeAttackSpeed;
        wizard = creatureController.dataForTheCreature.targetToAttack.GetComponent<WizardCombatController>();
        TurnManager.TurnTick += StartMeeleeIngTheTarget;
        creatureController.animationController.SetIdlingAnimationForCreature(creatureController.TheCreature);
    }

    void StartMeeleeIngTheTarget()
    {
        meleeCounter++;
        if (meleeCounter >= meleeAttackSpeed)
        {
            StartCoroutine(MeeleeTheTarget());
            meleeCounter = 0;
        }
        //if (creatureController.dataForTheCreature.currentHealth <= 0 || wizard.wizard.dataForWizard.dataOfWizardAttributes.currentHealth <= 0)
        //{
        //    creatureController.FightOver();
        //    TurnManager.TurnTick -= StartMeeleeIngTheTarget;
        //}
    }
    public void StopFighting()
    {
        TurnManager.TurnTick -= StartMeeleeIngTheTarget;
    }
    public IEnumerator MeeleeTheTarget()
    {
        if (creatureController.dataForTheCreature.currentHealth > 0)
            creatureController.animationController.SetAttackingAnimationForCreature(creatureController.TheCreature);
        yield return new WaitForSeconds(creatureController.dataForTheCreature.attackSpeed / 2);
        if (creatureController.dataForTheCreature.currentHealth > 0)
        {
            wizard.TakeDamage(creatureController.dataForTheCreature.dmgPerHit);
        }
    }
}
