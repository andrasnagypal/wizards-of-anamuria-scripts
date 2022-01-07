using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminingManager : MonoBehaviour
{
   
    public List<TaskInfoForTheWizard> availableExaminingSites = new List<TaskInfoForTheWizard>();


    public void AddExaminingSiteToList(TaskInfoForTheWizard info)
    {
       
        info.theGO.transform.SetParent(gameObject.transform);
        availableExaminingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableExaminingSites.Count > 0;
    }
}
