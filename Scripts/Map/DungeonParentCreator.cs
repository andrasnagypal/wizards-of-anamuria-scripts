using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonParentCreator : MonoBehaviour
{
    [SerializeField] GameObject dungeonParentPrefab;
    GameObject tempGO;
    public GameObject GetParentDungeon()
    {
        tempGO = Instantiate(dungeonParentPrefab, Vector3.zero, Quaternion.identity);
        return tempGO;
        
    }
}
