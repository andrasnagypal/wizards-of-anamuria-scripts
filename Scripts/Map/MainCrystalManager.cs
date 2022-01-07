using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCrystalManager : MonoBehaviour
{
    public Material[] materialsToUse;

    public void Awake()
    {
        GetComponent<MeshRenderer>().material = materialsToUse[(int)MapSelectionData.crystalOfTheGame];
    }
}
