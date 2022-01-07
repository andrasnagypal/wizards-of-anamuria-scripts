using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentManager : MonoBehaviour
{

    Dictionary<string, List<int[]>> continentsDictionary = new Dictionary<string, List<int[]>>();
    //[SerializeField] DesertManager desertManager;
    //[SerializeField] WastelandManager wastelandManager;
    //[SerializeField] FrozenlandManager frozenlandManager;
    //[SerializeField] SettlementManager settlementManager;
    //[SerializeField] ForestManager forestManager;
    //[SerializeField] MountainManager mountainManager;
    int startNumber = 0, wastelandNumber = 0, frozenNumber = 0, desertNumber = 0, mountainNumber = 0, settlementNumber = 0;
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Alpha2))
    //    {
    //        foreach (var item in continentsDictionary)
    //        {
    //            Debug.Log(item.Key);
    //            List<int[]> temp = new List<int[]>(); 
    //             temp=   continentsDictionary[item.Key];
    //            for (int i = 0; i < temp.Count; i++)
    //            {
    //                Debug.Log(temp[i][0].ToString()+" "+ temp[i][1]);
    //            }
    //        }
    //    }
    //}

    //public void AddContinentToDictionary(TerrainTypes terraintype, List<int[]> indexes)
    //{
    //    continentsDictionary.Add(GetNameForDictionary(terraintype), indexes);
    //}
    public void AddContinentToItsManager(TerrainTypes terraintype, List<int[]> indexes)
    {
        switch (terraintype)
        {
            case TerrainTypes.Forest:
                {
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        ForestManager.indexesForForestTiles.Add(indexes[i]);
                    }
                    
                }
                break;
            case TerrainTypes.Desert:
                for (int i = 0; i < indexes.Count; i++)
                {
                    DesertManager.indexesForDesertTiles.Add(indexes[i]);
                }
                break;
            case TerrainTypes.Frozen:
                for (int i = 0; i < indexes.Count; i++)
                {
                    FrozenlandManager.indexesForFrozenLandTiles.Add(indexes[i]);
                }
                break;
            case TerrainTypes.Wasteland:
                for (int i = 0; i < indexes.Count; i++)
                {
                    WastelandManager.indexesForWastelandTiles.Add(indexes[i]);
                }
                break;
            case TerrainTypes.Mountain:
               
                {
                    MountainManager.mountainIndexesInGame.Add(indexes);
                }
                break;
            case TerrainTypes.Settlement:
               
                {
                    SettlementManager.settlementIndexesInGame.Add(indexes);
                }
                break;
            case TerrainTypes.Start:
                break;
          
            case TerrainTypes.Dungeon:
                break;
           
        } 
    }


    public string GetDescriptionForATile(int[] indexes)
    {
        string temp=null;
        if (ForestManager.indexesForForestTiles.Contains(indexes))
        {
            temp = "Forest";
        }
        if (DesertManager.indexesForDesertTiles.Contains(indexes))
        {
            temp = "Desert";
        }
        if (WastelandManager.indexesForWastelandTiles.Contains(indexes))
        {
            temp = "Wasteland";
        }
        if (FrozenlandManager.indexesForFrozenLandTiles.Contains(indexes))
        {
            temp = "Frozen";
        }
        if (temp == null)
        {
            foreach (List<int[]> item in MountainManager.mountainIndexesInGame)
            {
                if (item.Contains(indexes))
                {
                    temp = "Mountain";
                }
            }
            foreach (List<int[]> item in SettlementManager.settlementIndexesInGame)
            {
                if (item.Contains(indexes))
                {
                    temp = "Settlement";
                }
            }
        }
        return temp;
    }
    //    string GetNameForDictionary(TerrainTypes terraintype)
    //{
    //    string temp=null;
    //    switch (terraintype)
    //    {
    //        case TerrainTypes.Forest:
    //            break;
    //        case TerrainTypes.Desert:
    //            {
    //                temp = "Desert " + desertNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Frozen:
    //            {
    //                temp = "Frozen " + frozenNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Wasteland:
    //            {
    //                temp = "Wasteland " + wastelandNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Mountain:
    //            {
    //                temp = "Mountain " + mountainNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Settlement:
    //            {
    //                temp = "Settlement " + settlementNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Start:
    //            {
    //                temp = "Start " + startNumber++;
    //            }
    //            break;
    //        case TerrainTypes.Cave:
    //            break;
    //        case TerrainTypes.Dungeon:
    //            break;
    //        case TerrainTypes.UnderGround:
    //            break;
    //    }
    //    return temp;
    //}
    
}