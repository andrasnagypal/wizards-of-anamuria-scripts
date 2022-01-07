using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokingManager : MonoBehaviour
{
    public List<TaskInfoForTheWizard> availableInvokingSites = new List<TaskInfoForTheWizard>();


    public void AddInvokingSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableInvokingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableInvokingSites.Count > 0;
    }
}
