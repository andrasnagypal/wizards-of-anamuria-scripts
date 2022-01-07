using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditatingManager : MonoBehaviour
{
    
    public List<TaskInfoForTheWizard> availableMeditatingSites = new List<TaskInfoForTheWizard>();


    public void AddMeditationSiteToList(TaskInfoForTheWizard info)
    {
        Debug.Log("mushroom added");
        info.theGO.transform.SetParent(gameObject.transform);
        availableMeditatingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableMeditatingSites.Count > 0;
    }
}
