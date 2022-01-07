using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMeshAndMatManager : MonoBehaviour
{
    public Mesh terrainMesh;
    public Material[] terrainMaterials;
    public static Mesh meshForTerrain;
    public static Material[] materialsForTerrain;

    private void Awake()
    {
        meshForTerrain = terrainMesh;
        materialsForTerrain = terrainMaterials;
    }



    public static Mesh GetMeshForTile(TerrainTypes terrain)
    {
        Mesh result=null;
       if(terrain!=TerrainTypes.Mountain)
        {
            result = meshForTerrain;
        }
        return result;
    }

    public static Material GetMaterialForTile(TerrainTypes terrain)
    {
        Material result = null;

        switch (terrain)
        {
            case TerrainTypes.Forest:
                {
                    result = materialsForTerrain[3];
                }
                break;
            case TerrainTypes.Desert:
                {
                    result = materialsForTerrain[0];
                }
                break;
            case TerrainTypes.Frozen:
                {
                    result = materialsForTerrain[4];
                }
                break;
            case TerrainTypes.Wasteland:
                {
                    result = materialsForTerrain[2];
                }
                break;
            case TerrainTypes.Mountain:
                break;
            case TerrainTypes.Settlement:
                {
                    result = materialsForTerrain[5];
                }
                break;
            case TerrainTypes.Start:
                break;
            case TerrainTypes.Dungeon:
                {
                    result = materialsForTerrain[1];
                }
                break;
        }

        return result;
    }

}
