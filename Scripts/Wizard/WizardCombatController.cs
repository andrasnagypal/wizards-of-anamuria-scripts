using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCombatController : MonoBehaviour
{
    public GameObject spawningPointForStaffProjectile;
    public WizardController wizard;
    CreatureController targetController;
    int meleeAttackSpeed,meleeCounter=0;
    public void StartAttackingTarget()
    {
        
        meleeAttackSpeed = (int)wizard.dataForWizard.combatData.meeleeSpeed * 100;
        meleeCounter = meleeAttackSpeed;
        targetController = wizard.dataForWizard.combatTarget.GetComponent<CreatureController>();
        TurnManager.TurnTick += StartMeeleeIngTheTarget;
    }

   public  void StartMeeleeIngTheTarget()
    {
        meleeCounter++;
        if(meleeCounter>=meleeAttackSpeed&& targetController.dataForTheCreature.currentHealth > 0 && wizard.dataForWizard.dataOfWizardAttributes.currentHealth > 0)
        {
            StartCoroutine(ShootProjectileToTarget());
            meleeCounter = 0;
        }
       // if(targetController.dataForTheCreature.currentHealth <= 0||wizard.dataForWizard.dataOfWizardAttributes.currentHealth<=0)
       //{
       //     wizard.FightOver();
            
       // }
    }

    public IEnumerator ShootProjectileToTarget()
    {
        if (wizard.dataForWizard.dataOfWizardAttributes.currentHealth > 0)
            wizard.animatorController.PlayStaffAttackAnimation(wizard.dataForWizard.combatData.meeleeSpeed);
        yield return new WaitForSeconds(wizard.dataForWizard.combatData.meeleeSpeed / 2);
        if (wizard.dataForWizard.dataOfWizardAttributes.currentHealth > 0)
        {
            GameObject temp = FindObjectOfType<FXPoolSystem>().GetStaffMissiles();
            temp.SetActive(true);
            temp.transform.position = spawningPointForStaffProjectile.transform.position;
            temp.GetComponent<StaffMissileController>().SetTarget(wizard.dataForWizard.combatTarget);
        }
    }

    public void TakeDamage(int dmg)
    {
        wizard.dataForWizard.dataOfWizardAttributes.currentHealth -= dmg;
        //if (wizard.dataForWizard.dataOfWizardAttributes.currentHealth <= 0 || targetController.dataForTheCreature.currentHealth <= 0)
        //{
          


        //    wizard.FightOver();
        //}
        if (PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn != null && UIManager.currentlyOpenPanel == LayoutType.CombatPanel)
        {
            FindObjectOfType<UI_CombatPanelController>().RefreshUI();
        }

        
        

    }

   
}
