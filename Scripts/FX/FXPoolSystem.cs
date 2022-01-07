using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXPoolSystem : MonoBehaviour
{
    public static Queue<GameObject> staffMissiles = new Queue<GameObject>();




    public GameObject GetStaffMissiles()
    {
        if (staffMissiles.Count < 5)
            MakeStaffMissiles();

        return staffMissiles.Dequeue();
    }

    public void MakeStaffMissiles()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(FindObjectOfType< EffectsManager>().wizardEffectsDictionary[WizardEffects.StaffMissile]);
            temp.SetActive(false);
            staffMissiles.Enqueue(temp);
        }
    }
}
