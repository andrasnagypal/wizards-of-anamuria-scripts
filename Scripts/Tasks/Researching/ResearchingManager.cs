using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchingManager : MonoBehaviour
{
    public List<TaskInfoForTheWizard> availableResearchingSites = new List<TaskInfoForTheWizard>();


    public void AddResearchingSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableResearchingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableResearchingSites.Count > 0;
    }
}
