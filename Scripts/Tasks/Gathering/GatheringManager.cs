using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GatheringManager : MonoBehaviour
{
   
    public Queue<TaskInfoForTheWizard> availableGatheringSites = new Queue<TaskInfoForTheWizard>();


    public void AddGatheringSitesToList(TaskInfoForTheWizard info)
    {
        Debug.Log("mushroom added");
      //  info.theGO.transform.SetParent(gameObject.transform);
        availableGatheringSites.Enqueue(info);
    }

    public bool IsThereASiteToPerformTaskOn()
    {
        return availableGatheringSites.Count > 0;
    }
    public TaskInfoForTheWizard GetTaskForWizard()
    {
        TaskInfoForTheWizard result = availableGatheringSites.Dequeue();
        return result;
    }
}
