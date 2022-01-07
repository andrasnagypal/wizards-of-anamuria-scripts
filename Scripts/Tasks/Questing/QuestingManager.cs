using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestingManager : MonoBehaviour
{
    public List<TaskInfoForTheWizard> availableQuestingSites = new List<TaskInfoForTheWizard>();


    public void AddQuestingSiteToList(TaskInfoForTheWizard info)
    {

        info.theGO.transform.SetParent(gameObject.transform);
        availableQuestingSites.Add(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableQuestingSites.Count > 0;
    }
}
