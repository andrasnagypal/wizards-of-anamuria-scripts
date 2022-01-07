using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CombatPanelController : MonoBehaviour
{
    public int[] indexesForCurrentCombat;

    public GameObject wizardsParent,creaturesParent;

    public void SetUpUI(CombatData data)
    {
        CloseAllParticipant();
        for (int i = 0; i < data.wizardsInCombat.Count; i++)        
        {
            wizardsParent.transform.GetChild(i).gameObject.SetActive(true);
            UI_BattleParticipantController temp2 = wizardsParent.transform.GetChild(i).gameObject.GetComponent<UI_BattleParticipantController>();
        temp2.ChangeCharacterPortrait(FindObjectOfType<UIManager>().wizardPortraits[data.wizardsInCombat[i].dataForWizard.wizardPortraitVariant]);
        temp2.ChangeFocusPercentage("10%/hit");
        temp2.ChangeHP(data.wizardsInCombat[i].dataForWizard.dataOfWizardAttributes.currentHealth.ToString() + "/" + data.wizardsInCombat[i].dataForWizard.dataOfWizardAttributes.maxHealth.ToString());
        temp2.ChangeHPScrollbar((float)data.wizardsInCombat[i].dataForWizard.dataOfWizardAttributes.currentHealth / data.wizardsInCombat[i].dataForWizard.dataOfWizardAttributes.maxHealth);
        temp2.ChangeId(data.wizardsInCombat[i].dataForWizard.dataOfWizardAttributes.wizardId);
    }
        for (int i = 0; i < data.creaturesInCombat.Count; i++)
        {
            creaturesParent.transform.GetChild(i).gameObject.SetActive(true);
            UI_BattleParticipantController temp2 = creaturesParent.transform.GetChild(i).gameObject.GetComponent<UI_BattleParticipantController>();
            temp2.SetEnemyParticipant();
            temp2.ChangeCharacterPortrait(FindObjectOfType<CreatureManager>().GetCreaturePortraitForUI(data.creaturesInCombat[i].dataForTheCreature.typeOfCreature));
            temp2.ChangeFocusPercentage("10%/hit");
            temp2.ChangeHP(data.creaturesInCombat[i].dataForTheCreature.currentHealth.ToString() + "/" + data.creaturesInCombat[i].dataForTheCreature.maxHealth.ToString());
            temp2.ChangeHPScrollbar((float)data.creaturesInCombat[i].dataForTheCreature.currentHealth / data.creaturesInCombat[i].dataForTheCreature.maxHealth);
            temp2.ChangeId(data.creaturesInCombat[i].dataForTheCreature.createId);
        }
    }


    public void CloseAllParticipant()
    {
        for (int i = 0; i < wizardsParent.transform.childCount; i++)
        {
            wizardsParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < creaturesParent.transform.childCount; i++)
        {
            creaturesParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        
        FindObjectOfType<CombatArenaManager>().SwitchBattleAlerter(PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn);
      
        PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn = null;
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.CombatPanel);
    }

    private void OnEnable()
    {
        RefreshUI();
    }
    private void OnDisable()
    {
        
    }
    public void RefreshUI()
    {
        indexesForCurrentCombat = PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn;
       
        //if (FindObjectOfType<CombatArenaManager>().isThisACombatArea(indexesForCurrentCombat))
        //{
        //    CombatData temp = FindObjectOfType<CombatArenaManager>().GetCombatData(indexesForCurrentCombat);
        //    SetUpUI(temp);
        //}
        //else
        //    ClosePanel();
    }
}
