using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitingManager : MonoBehaviour
{
    public List<TaskInfoForTheWizard> availableVisitingSites = new List<TaskInfoForTheWizard>();


    public void AddVisitingSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableVisitingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableVisitingSites.Count > 0;
    }
}
