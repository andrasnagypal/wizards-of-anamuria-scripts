using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentingManager : MonoBehaviour
{
    
    public List<TaskInfoForTheWizard> availableExperimentingSites = new List<TaskInfoForTheWizard>();


    public void AddExperimentingSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableExperimentingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableExperimentingSites.Count > 0;
    }
}
