using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public TilePropContainer propContainer;
    public int howManyPerPool,howManyGrassOnMap;
    Queue<GameObject> grass1Pool = new Queue<GameObject>();
    Queue<GameObject> grass2Pool = new Queue<GameObject>();
    Queue<GameObject> grass3Pool = new Queue<GameObject>();
    Queue<GameObject> grass4Pool = new Queue<GameObject>();
    Queue<GameObject> grass5Pool = new Queue<GameObject>();
    GenerateMap theMap;

    public  void StartAddingGrassToTiles()
    {
        if(theMap==null)
        {
            theMap = FindObjectOfType<GenerateMap>();
        }
         AddNatureToTiles();
    }

    private void AddNatureToTiles()
    {
        int rndX = UnityEngine.Random.Range(0, GenerateMap.mapSizeX);
        int rndY = UnityEngine.Random.Range(0, GenerateMap.mapSizeY);
       
       
        
            for (int i = 0; i < howManyGrassOnMap; i++)
            {
                if (theMap.terrainTiles[rndX, rndY].typeOfTerrain == TerrainTypes.Forest)
                {
                    int rnd = Random.Range(0, 5);
                theMap.terrainTiles[rndX, rndY].AddNatureToTile(  GetForestGrass(rnd));
                }
                rndX = UnityEngine.Random.Range(0, GenerateMap.mapSizeX);
                rndY = UnityEngine.Random.Range(0, GenerateMap.mapSizeY);
            }
            
       
        
        
            for (int i = 0; i < GenerateMap.mapSizeX; i++)
            {
                for (int j = 0; j < GenerateMap.mapSizeY; j++)
                {
                theMap.terrainTiles[i, j].RemoveUnusedNaturePlaces();
                }
            }
        
        
    }
    public  GameObject GetForestGrass(int indexOfGrassTsype)
    {
        GameObject result=null;

       
        
            switch (indexOfGrassTsype)
            {
                case 0:
                    {
                        result = GetItemFromThisPool(grass1Pool, PropType.Grass1);
                    }
                    break;
                case 1:
                    {
                        result = GetItemFromThisPool(grass2Pool, PropType.Grass2);
                    }
                    break;
                case 2:
                    {
                        result = GetItemFromThisPool(grass3Pool, PropType.Grass3);
                    }
                    break;
                case 3:
                    {
                        result = GetItemFromThisPool(grass4Pool, PropType.Grass4);
                    }
                    break;
                case 4:
                    {
                        result = GetItemFromThisPool(grass5Pool, PropType.Grass5);
                    }
                    break;
            }
        

        return  result;
    }

    public GameObject GetItemFromThisPool(Queue<GameObject> thePool,PropType theItemTypeForInstantiation)
    {
        GameObject temp = null;
        if(thePool.Count<howManyPerPool/10)
        {
            for (int i = 0; i < howManyPerPool; i++)
            {
                temp = Instantiate(propContainer.GetProp(theItemTypeForInstantiation), transform);
                temp.transform.position = new Vector3(0, -100, 0);
                thePool.Enqueue(temp);
            }
        }

        return thePool.Dequeue();
    }


}
