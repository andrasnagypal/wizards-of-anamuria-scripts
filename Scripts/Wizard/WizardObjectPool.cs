using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WizardModelVariant : byte
{
   
    Wizard1,
    Wizard2,
    Wizard3,
    Wizard4,
    Wizard5,
    Wizard6,
    Wizard7,
    Wizard8,
    Wizard9,
    Wizard10,
    Wizard11,
    Wizard12,
    Wizard13,
    Wizard14,
    Wizard15,
    WizardLady1,
    WizardLady2,
    WizardLady3,
    WizardLady4,
    WizardLady5,
    WizardLady6,
    WizardLady7,
    WizardLady8,
    WizardLady9,
    WizardLady10,
    WizardLady11,
    WizardLady12,
    WizardLady13,
    WizardLady14,
    WizardLady15

}
public class WizardObjectPool : MonoBehaviour
{
    public GameObject[] wizardPrefabs;
    public Material[] wizardStaffMaterials;
    public List<Material> materialsForWizards = new List<Material>();
    [SerializeField] int howManyWizardPerPool;
    Queue<GameObject> wizardPool = new Queue<GameObject>();
    int rndWizard,rndModel;
   

    private void Awake()
    {
        MakeWizards();
    }

    public GameObject GetWizard()
    {
       
        if (wizardPool.Count < 5)
            MakeWizards();
        return wizardPool.Dequeue();
    }

    void MakeWizards()
    {
        GameObject temp;
        for (int i = 0; i < howManyWizardPerPool; i++)
        {
            rndWizard = Random.Range(0, wizardPrefabs.Length);
            temp = Instantiate(wizardPrefabs[rndWizard]);
            rndModel = Random.Range(0, 15);
            temp.GetComponentInChildren<SkinnedMeshRenderer>().material = materialsForWizards[rndModel];
            temp.GetComponent<WizardController>().modelForTheWizard =  (WizardModelVariant)(rndWizard * 15 + rndModel);
            temp.GetComponent<WizardController>().wizardStaff.material=wizardStaffMaterials[(int)MapSelectionData.crystalOfTheGame];
            temp.SetActive(false);
            wizardPool.Enqueue(temp);
        }
    }

}
