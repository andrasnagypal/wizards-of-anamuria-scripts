using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PavementData
{
    public float size;
    public int[] indexes;
    public GameObject pavement;
}
public class PlayerTilesManager : MonoBehaviour
{

    public GameObject cornerBuildingSelector;
    static GenerateMap theMap;
    public static List<TerrainTypeContainer> terrainsThePlayerHasBuildingOn = new List<TerrainTypeContainer>();

    public static List<GameObject> currentlyActiveForPlayerToChoosePlacesList = new List<GameObject>();


    List<PavementData> pavementsInGame = new List<PavementData>();
    private void Awake()
    {
        theMap = FindObjectOfType<GenerateMap>();
        terrainsThePlayerHasBuildingOn = new List<TerrainTypeContainer>();
        currentlyActiveForPlayerToChoosePlacesList = new List<GameObject>();
    }


   

    public void AddOrIncreasePavement(int[] indexes)
    {
        PavementData temp = new PavementData {size=-1 };
        foreach (PavementData item in pavementsInGame)
        {
            if(item.indexes[0]==indexes[0]&& item.indexes[1] == indexes[1])
            {
                temp=item;
                break;
            }
        }

        if(temp.size>=0)
        {
            Debug.Log("Before " + temp.size);
            temp.size += .25f;
            Debug.Log("After " + temp.size);
            temp.pavement.transform.localScale += new Vector3(1 * .25f, 1, 1 * .25f);
            Debug.Log("Size of pavement: " + temp.size);
        }
        else
        {
            temp = new PavementData
            {
                size = .25f,
                indexes = indexes,
                pavement =Instantiate( FindObjectOfType<TilePropContainer>().GetProp(PropType.Pavement1))
            };
            GameObject tile = FindObjectOfType<GenerateMap>().GetTerrainForCharacter(indexes).gameObject;
           
            temp.pavement.transform.position = tile.transform.position;

            temp.pavement.transform.localScale = new Vector3(1*temp.size,1,1 * temp.size);
            pavementsInGame.Add(temp);
        }
    }

    public static void BuildingUISelected()
    {
        ShowAllNeighborTilePotentialBuilding();
        TurnOnAvailableChoicesForPlayer();
    }
    public static void CancelAllSelectionForBuildings()
    {
        foreach (GameObject item in currentlyActiveForPlayerToChoosePlacesList)
        {
            item.SetActive(false);
        }
    }
    public static void ShowAllNeighborTilePotentialBuilding()
    {
        foreach (TerrainTypeContainer item in terrainsThePlayerHasBuildingOn)
        {
            theMap.SetupBuildingSelectorsForUse(item);
        }
    }
    public static void TurnOnAvailableChoicesForPlayer()
    {
        foreach (GameObject item in currentlyActiveForPlayerToChoosePlacesList)
        {
            item.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        terrainsThePlayerHasBuildingOn = new List<TerrainTypeContainer>();
        currentlyActiveForPlayerToChoosePlacesList = new List<GameObject>();
    }
}
