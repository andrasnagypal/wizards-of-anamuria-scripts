using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MountainTopType:byte
{
    Nothing,
    MountainCenter,
    MountainNorth1side,
    MountainEast1side,
    MountainSouth1side,
    MountainWest1side,
    MountainNorthEast2side,
    MountainSouthEast2side,
    MountainSouthWest2side,
    MountainNorthWest2side,
    MountainNorthSouth2side,
    MountainWestEast2side,
    MountainNorthEastSouth3side,
    MountainEastSouthWest3side,
    MountainSouthWestNorth3side,
    MountainWestNorthEast3side,
    Mountain4side,
    MountainSummit    
}

public class MountainGenerator : MonoBehaviour
{
    [Range(5,25)]
    [SerializeField] int maxHeight;
    int rndHeight;
    
  

    public Dictionary<int[],List<MountainTopType>> GetTypeOfMountainTops(List<int[]> tileIndexes)
    {
        Dictionary<int[], List<MountainTopType>> result = new Dictionary<int[], List<MountainTopType>>();
        rndHeight = Random.Range(5, maxHeight);
        foreach (int[] item in tileIndexes)
        {
            MountainTopType[] resulttemp = new MountainTopType[rndHeight];
            
            result.Add(item, new List<MountainTopType>(resulttemp));
        }

       

        List<int[]> indexesThatNeedToBeSpawned = new List<int[]>();
        List<int> temp= new List<int>();
        int rnd,rndIndex;
        for (int i = 0; i < tileIndexes.Count; i++)
        {
            temp.Add(i);
        }
        for (int i = 0; i < rndHeight; i++)
        {
            if (i > 2)
            {
                rnd = Random.Range(1, 3);
            }
            else rnd = 0;
            for (int j = 0; j < rnd* rndHeight/3; j++)
            {
                rndIndex = Random.Range(0, temp.Count);
                if (temp.Count>0)
                temp.RemoveAt(rndIndex);
            }
            if (i != rndHeight - 1)
                indexesThatNeedToBeSpawned.Add(temp.ToArray());
            else
                indexesThatNeedToBeSpawned.Add(new int[] { });
        }
        for (int i = 0; i < indexesThatNeedToBeSpawned.Count; i++)
        {
            for (int j = 0; j < indexesThatNeedToBeSpawned[i].Length; j++)
            {
                result[tileIndexes[indexesThatNeedToBeSpawned[i][j]]][i] = MountainTopType.MountainCenter;
            }
        }
       

        return result;
    }
}
