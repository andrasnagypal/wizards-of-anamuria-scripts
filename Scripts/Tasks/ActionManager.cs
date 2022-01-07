using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct TaskInfoForTheWizard
{
    public WizardAction typeOfGO;
    public GameObject theGO;
    public int[] tileIndexForTheGO;
}
public class ActionManager : MonoBehaviour
{
    public static QuestingManager questManager;
    public static ExaminingManager examiningManager;
    public static VisitingManager visitingManager;
    public static GatheringManager gatheringManager;
    public static MeditatingManager meditatingManager;
    public static ResearchingManager researchingManager;
    public static GardeningManager gardeningManager;
    public static ExperimentingManager experimentingManager;
    public static InvokingManager invokingManager;


    public void Awake()
    {
        questManager = GetComponent<QuestingManager>();
        examiningManager = GetComponent<ExaminingManager>();
        visitingManager = GetComponent<VisitingManager>();
        gatheringManager = GetComponent<GatheringManager>();
        meditatingManager = GetComponent<MeditatingManager>();
        researchingManager = GetComponent<ResearchingManager>();
        gardeningManager = GetComponent<GardeningManager>();
        experimentingManager = GetComponent<ExperimentingManager>();
        invokingManager = GetComponent<InvokingManager>();
}
}
