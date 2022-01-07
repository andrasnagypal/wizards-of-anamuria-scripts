using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlacementOfPavementOnTile:byte
{
    Start,
    West,
    NorthWest,
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest
}

public struct TileInfoAboutPavements
{
    public int[] tileIndexes;
    public List<PlacementOfPavementOnTile> pavementsOnTile;
}


public class PavementController : MonoBehaviour
{
    public List<TileInfoAboutPavements> pavementsOnTilesData = new List<TileInfoAboutPavements>();


    public void PutDownNewPavement(TileInfoAboutPavements pavementData)
    {
        bool isPavementSpawnable = false;

        foreach (TileInfoAboutPavements item in pavementsOnTilesData)
        {
            if(!item.pavementsOnTile.Contains(pavementData.pavementsOnTile[0])&&item.tileIndexes[0]==pavementData.tileIndexes[0]&& item.tileIndexes[1] == pavementData.tileIndexes[1])
            {
                isPavementSpawnable = true;
                break;
            }
        }
        if(isPavementSpawnable)
        {
            GameObject floor = Instantiate(FindObjectOfType<TilePropContainer>().GetProp(PropType.Pavement1));
            
           TerrainTypeContainer temp= FindObjectOfType<GenerateMap>().GetTerrainForCharacter(pavementData.tileIndexes);
            temp.SetRoadOnTile(floor, pavementData.pavementsOnTile[0]);
            floor.transform.SetParent(gameObject.transform);
        }
    }
}
