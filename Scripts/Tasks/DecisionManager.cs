using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DecisionManager : MonoBehaviour
{
    public GatheringManager gatheringManager;
  

    public WizardAction GetActionFromChances(WizardActionChances wizardChances)
    {
        WizardAction result = WizardAction.Wandering;
        //byte[] chances = new byte[15];
        //int altogether = 0;
        //chances[0] = (wizardChances.Wandering);
        //chances[1] = (wizardChances.Questing );
        //if (gatheringManager.availableGatheringSites.Count > 0)
        //    chances[2] = (byte)(wizardChances.Gathering +1);
        //else
        //{
        //    chances[2] = 0;
        //}
        //chances[3] = (wizardChances.Examining );
        //chances[4] = (wizardChances.Visiting );
        //chances[5] = (wizardChances.Meditating );
        //chances[6] = (wizardChances.Experimenting );
        //chances[7] = (wizardChances.Gardening);
        //chances[8] = (wizardChances.Research );
        //chances[9] = (wizardChances.Invoking );
        //for (int i = 0; i < chances.Length; i++)
        //{
        //    altogether += chances[i];
        //}
        //int rndChance = Random.Range(0, altogether);
        //for (int i = 0; i < chances.Length; i++)
        //{
        //    if (chances[i] > 0)
        //    {
        //        if (altogether - chances[i] < rndChance)
        //        {
        //            result = (WizardAction)((int)WizardAction.Wandering + i);
        //        }
        //        else
        //            altogether -= chances[i];
        //    }
        //}
        return result;
    }


    public TaskInfoForTheWizard GetTaskForWizard(WizardAction action)
    {
        TaskInfoForTheWizard result= new TaskInfoForTheWizard
        {
            theGO = null,
            tileIndexForTheGO = null,
            typeOfGO = WizardAction.InTransitToTask
        };
        switch (action)
        {
            case WizardAction.Wandering:
                break;
            case WizardAction.Questing:
                break;
            case WizardAction.Gathering:
                {
                    result = gatheringManager.GetTaskForWizard();
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
                break;
            case WizardAction.InTransitToTask:
                break;
            case WizardAction.Stasis:
                break;
        };

        return result;
    }
}
