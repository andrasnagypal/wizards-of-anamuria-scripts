using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public enum WizardAction:byte
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
    Stasis
}

public class WizardController : MonoBehaviour
{
    public WizardSetupData dataForWizard;
    public bool isOnTargetTile=false;
    public Transform targetToInteractWith;
    public GenerateMap theMap;
    public WizardMovementController movementController;
    public UI_WizardPortrait portrait;
   
    public WizardCombatController combatController;
    public WizardAnimationController animatorController;
    public WizardModelVariant modelForTheWizard;
    public List<int> PathTest = new List<int>();
    public MeshRenderer wizardStaff;
   
    public List<WizardAction> actionsTakenByCharacter = new List<WizardAction>();
    public void SetupTheWizard(WizardSetupData data)
    {

       
        dataForWizard = data;
        theMap = FindObjectOfType<GenerateMap>();
    SetupAction(WizardAction.Wandering);
        TurnManager.NextTurn += TurnChange;
    }
    

   

   

    public void FightOver()
    {
        TurnManager.TurnTick -= combatController.StartMeeleeIngTheTarget;
        
        dataForWizard.combatTarget = null;
        if (dataForWizard.dataOfWizardAttributes.currentHealth <= 0 )
        {

            SetupAction(WizardAction.Stasis);
            return;
        }
        else
        {
            
            SetupAction(GetLastNonFightAction());
            //if (!FindObjectOfType<CombatArenaManager>().isThisACombatArea(dataForWizard.tileWizardIsOn))
            //    SetupAction(GetLastNonFightAction());
            //else
            //    FindObjectOfType<CombatArenaManager>().SearchForEnemyWithThisIndexes(dataForWizard.tileWizardIsOn);
        }
        
    }
    
   
    public void TurnChange()
    {
        if(actionsTakenByCharacter[actionsTakenByCharacter.Count-1]!= WizardAction.Fighting&& actionsTakenByCharacter[actionsTakenByCharacter.Count - 1] != WizardAction.Stasis && actionsTakenByCharacter[actionsTakenByCharacter.Count - 1] != WizardAction.InTransitToTask)
        dataForWizard.howLongActionWillTake--;
       
        TurnManager.UpdateCharacterInfo();
    }


    public async void SetupAction(WizardAction action)
    {

        actionsTakenByCharacter.Add(action);




       
        switch (action)
        {
            case WizardAction.Wandering:
                {
                   
                    if (dataForWizard.howLongActionWillTake<=0)
                    {
                        dataForWizard.howLongActionWillTake = Random.Range(1, 10);
                    }
                   
                  
                    
                   
                    
                  
                    movementController.StartWandering();
                    
                    
                }
                break;
            case WizardAction.Questing:
                break;
            case WizardAction.Gathering:
                {
                    actionsTakenByCharacter.Add(WizardAction.InTransitToTask);
                    if(dataForWizard.currentTaskInfoForTheWizard.theGO==null)
                    {
                        dataForWizard.currentTaskInfoForTheWizard = FindObjectOfType<DecisionManager>().GetTaskForWizard(action);
                    }
                    if (Vector3.Distance(dataForWizard.currentTaskInfoForTheWizard.theGO.transform.position, gameObject.transform.position) > .1f)
                        movementController.StartJourneyingToTheTaskPlace();
                    else
                        Debug.Log("start gathering");
                }
                break;
            case WizardAction.Examining:
                break;
            case WizardAction.Visiting:
                break;
            case WizardAction.Meditating:
                break;
            case WizardAction.Experimenting:
                break;
            case WizardAction.Gardening:
                break;
            case WizardAction.Research:
                break;
            case WizardAction.Invoking:
                break;
            case WizardAction.Arcane:
                break;
            case WizardAction.Destruction:
                break;
            case WizardAction.Protection:
                break;
            case WizardAction.Mysticism:
                break;
            case WizardAction.Conjuring:
                break;
            case WizardAction.Alchemy:
                break;
            case WizardAction.DarkMagic:
                break;
            case WizardAction.Fighting:
                {
                    
                   
                    movementController.StopMoving();
                    TurnChange();
                    transform.LookAt(dataForWizard.combatTarget.transform.position);
                   
                 
                    combatController.StartAttackingTarget();
                }
                break;
            
            case WizardAction.Stasis:
                {
                    /*if(actionsTakenByCharacter.Count>2&&actionsTakenByCharacter[actionsTakenByCharacter.Count-1]!=WizardAction.Stasis)*///if (actionsTakenByCharacter.Count > 2 && actionsTakenByCharacter[actionsTakenByCharacter.Count - 2] != WizardAction.Stasis)
                    {

                        //FindObjectOfType<CombatArenaManager>().RemoveWizardFromCombatArea(this);


                        animatorController.PlayDyingAnimation();
                        portrait.transform.SetParent(null);
                        portrait.gameObject.SetActive(false);
                        FindObjectOfType<UI_PopUpManager>().AddNewPopUp(PopUpType.Stasis, gameObject);
                        StartCoroutine(MakeTheBodyDisappaer());
                    }
                }
                break;
        }

        
    }

    public WizardAction GetLastNonFightAction()
    {
        WizardAction result=WizardAction.Wandering;
        Debug.Log("Count of the list=" + actionsTakenByCharacter.Count+" "+dataForWizard.wizardName);
        for (int i = actionsTakenByCharacter.Count-1; i>=0; i--)
        {
            if(actionsTakenByCharacter[i]!=WizardAction.Fighting)
            {
                result = actionsTakenByCharacter[i];
                break;
            }
        }
        Debug.Log("Count of the list=" + actionsTakenByCharacter.Count);
        return result;
    }

    IEnumerator MakeTheBodyDisappaer()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
    public void ShowInfo()
    {
        FindObjectOfType<UIManager>().SwitchPanel(LayoutType.CharacterInfo);
        
        FindObjectOfType<CharacterInfoController>().SetCurrentUIFromThisData(dataForWizard);
    }


   

    private void OnMouseEnter()
    {
        if (UIManager.currentlyOpenPanel == LayoutType.Closed)
            ShowWizardPopUpInfo();
    }
    private void OnMouseExit()
    {
        ClosePopUpInfo();
    }
    public void ShowWizardPopUpInfo()
    {
        FindObjectOfType<UIManager>().SwitchPanel(LayoutType.InfoPopUpForPlayer);
        InfoPopUpData temp = new InfoPopUpData
        {
            character = FindObjectOfType<UIManager>().wizardPortraits[dataForWizard.wizardPortraitVariant],
            characterName = dataForWizard.wizardName,
            hpStatus = dataForWizard.dataOfWizardAttributes.currentHealth + "/" + dataForWizard.dataOfWizardAttributes.maxHealth,
            focusStatus = "0"

        };

        FindObjectOfType<InfoPopupController>().SetInfoPopUpUI(temp);
    }
    public void ClosePopUpInfo()
    {
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.InfoPopUpForPlayer);
    }
}
