using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] GameObject dungeonsParent,dungeonTilePrefab;
    [SerializeField] int dungeonNumber, startX, incrementX,dungeonSize,howManyBranchPerDungeon,howManyMaxTilesPerBranch;
    [SerializeField] DungeonParentCreator dungeonParentManager;
    [SerializeField] TilePropContainer envManager;
    int rnd,rndX,rndY,rndTilesPerBranch;
    Direction rndDirection;
    List<TerrainTypes[,]> dungeonsMap = new List<TerrainTypes[,]>();
    List<List<DungeonTileController>> listOfDungeons = new List<List<DungeonTileController>>();
    List<DungeonTileController> templistForController = new List<DungeonTileController>();
    TerrainTypes[,] tempMap;
    GameObject tempGO,tempParent;
    List<int[]> indexOfDungeonTilesToSpawn = new List<int[]>();
    private void Start()
    {
        CreateDungeons();
       
    }

    PropType GetWallType(TerrainTypes[,] map,int x,int y)
    {
        bool[] directions = new bool[4];
        int typeOfRoom;
        if (y + 1 < dungeonSize)
        {

            if (map[x, y + 1] == TerrainTypes.Dungeon)
            {

                directions[0] = true;
            }
        }
        if (x + 1 < dungeonSize)
        {

            if (map[x + 1, y] == TerrainTypes.Dungeon)
            {

                directions[1] = true;
            }
        }
        if (y - 1 >= 0)
        {

            if (map[x, y - 1] == TerrainTypes.Dungeon)
            {

                directions[2] = true;
            }
        }
        if (x - 1 >= 0)
        {

            if (map[x - 1, y] == TerrainTypes.Dungeon)
            {

                directions[3] = true;
            }
        }
        typeOfRoom = GetDirectionForATileProp(directions);
        return (PropType)((int)PropType.DungeonRoomCenter+typeOfRoom);
    }
   
    void CreateDungeons()
    {
        for (int i = 0; i < dungeonNumber; i++)
        {
            tempMap = new TerrainTypes[dungeonSize, dungeonSize];
            dungeonsMap.Add(tempMap);
        }
        foreach (TerrainTypes[,] item in dungeonsMap)
        {


            {
                rndX = UnityEngine.Random.Range(0, dungeonSize);
                rndY = UnityEngine.Random.Range(0, dungeonSize);
                item[rndX, rndY] = TerrainTypes.Dungeon;
            }
            indexOfDungeonTilesToSpawn = new List<int[]>();
            indexOfDungeonTilesToSpawn.Add(new int[] { rndX, rndY });
            for (int i = 0; i < howManyBranchPerDungeon; i++)
            {
                rnd = UnityEngine.Random.Range(0, indexOfDungeonTilesToSpawn.Count);
                rndDirection = (Direction)UnityEngine.Random.Range(0, 4);
                CreateDungeonBranch(item, new int[] { indexOfDungeonTilesToSpawn[rnd][0], indexOfDungeonTilesToSpawn[rnd][1] }, rndDirection);
            }

        }



        for (int currentmap = 0; currentmap < dungeonsMap.Count; currentmap++)
        {
            templistForController = new List<DungeonTileController>();
            tempParent = dungeonParentManager.GetParentDungeon();
            for (int i = 0; i < dungeonSize; i++)
            {

                for (int j = 0; j < dungeonSize; j++)
                {

                    if (dungeonsMap[currentmap][i, j] == TerrainTypes.Dungeon)
                    {
                        tempGO = Instantiate(dungeonTilePrefab, new Vector3(startX + (currentmap * incrementX) + i, 0, j), dungeonTilePrefab.transform.rotation);
                        //Debug.Log("Dungeon wall: " + GetWallType(dungeonsMap[currentmap], i, j).ToString());
                        GameObject envWall = Instantiate(envManager.GetProp(GetWallType(dungeonsMap[currentmap], i, j)), new Vector3(startX + (currentmap * incrementX) + i, 0, j), Quaternion.identity);
                        envWall.transform.SetParent(tempGO.transform);
                        envWall.name="DungeonWall "+i+j+" " +GetWallType(dungeonsMap[currentmap], i, j).ToString();
                        tempGO.transform.SetParent(tempParent.transform);
                        templistForController.Add(tempGO.GetComponent<DungeonTileController>());
                    }
                }
            }
            tempParent.name = "Dungeon_" + currentmap.ToString();
            tempParent.transform.SetParent(dungeonsParent.transform);
            listOfDungeons.Add(templistForController);
        }
    }


    void CreateDungeonBranch(TerrainTypes[,] dungeonMap, int[] startingIndexes,Direction directionToSpawn)
    {
        switch (directionToSpawn)
        {
            case Direction.North:
                {
                    if (startingIndexes[1] + howManyMaxTilesPerBranch > dungeonSize)
                    {
                        rndTilesPerBranch = dungeonSize - startingIndexes[1];
                    }
                    else
                        rndTilesPerBranch = howManyMaxTilesPerBranch;

                    for (int i = 0; i < rndTilesPerBranch; i++)
                    {
                        if(dungeonMap[startingIndexes[0],startingIndexes[1]+i]!=TerrainTypes.Dungeon)
                        {
                            dungeonMap[startingIndexes[0], startingIndexes[1] + i] = TerrainTypes.Dungeon;
                            indexOfDungeonTilesToSpawn.Add(new int[] { startingIndexes[0], startingIndexes[1] + i });
                        }
                    }
                }
                break;
            case Direction.East:
                {
                    if (startingIndexes[0] + howManyMaxTilesPerBranch > dungeonSize)
                    {
                        rndTilesPerBranch = dungeonSize - startingIndexes[0];
                    }
                    else
                        rndTilesPerBranch = howManyMaxTilesPerBranch;

                    for (int i = 0; i < rndTilesPerBranch; i++)
                    {
                        if (dungeonMap[startingIndexes[0]+i, startingIndexes[1] ] != TerrainTypes.Dungeon)
                        {
                            dungeonMap[startingIndexes[0] + i, startingIndexes[1] ] = TerrainTypes.Dungeon;
                            indexOfDungeonTilesToSpawn.Add(new int[] { startingIndexes[0] + i, startingIndexes[1]  });
                        }
                    }
                }
                break;
            case Direction.South:
                {
                    if (startingIndexes[1] - howManyMaxTilesPerBranch < 0)
                    {
                        rndTilesPerBranch =  startingIndexes[1];
                    }
                    else
                        rndTilesPerBranch = howManyMaxTilesPerBranch;

                    for (int i = 0; i < rndTilesPerBranch; i++)
                    {
                        if (dungeonMap[startingIndexes[0], startingIndexes[1] - i] != TerrainTypes.Dungeon)
                        {
                            dungeonMap[startingIndexes[0], startingIndexes[1] - i] = TerrainTypes.Dungeon;
                            indexOfDungeonTilesToSpawn.Add(new int[] { startingIndexes[0], startingIndexes[1] - i });
                        }
                    }
                }
                break;
            case Direction.West:
                {
                    if (startingIndexes[0] - howManyMaxTilesPerBranch <0)
                    {
                        rndTilesPerBranch = startingIndexes[0];
                    }
                    else
                        rndTilesPerBranch = howManyMaxTilesPerBranch;

                    for (int i = 0; i < rndTilesPerBranch; i++)
                    {
                        if (dungeonMap[startingIndexes[0] - i, startingIndexes[1]] != TerrainTypes.Dungeon)
                        {
                            dungeonMap[startingIndexes[0] - i, startingIndexes[1]] = TerrainTypes.Dungeon;
                            indexOfDungeonTilesToSpawn.Add(new int[] { startingIndexes[0] - i, startingIndexes[1] });
                        }
                    }
                }
                break;
            default:
                break;
        }

        
    }
    public Vector3 GetDungeonPosition(int index)
    {
        GameObject temp = dungeonsParent.transform.GetChild(index).gameObject;
        
        return temp.transform.GetChild(UnityEngine.Random.Range(0, temp.transform.childCount)).position; 
    }

    int GetDirectionForATileProp(bool[] directions)
    {
        int result = 0;
        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i])
            {
                result += (int)Math.Pow(2, i);
            }
        }
        if (result==15)
        {
           // Debug.Log("BOSS PLACE");
        }
        return result;
    }
}
