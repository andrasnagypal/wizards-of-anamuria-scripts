using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardeningManager : MonoBehaviour
{
    
    public List<TaskInfoForTheWizard> availableGardeningSites = new List<TaskInfoForTheWizard>();


    public void AddGardeningSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableGardeningSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableGardeningSites.Count > 0;
    }
}
