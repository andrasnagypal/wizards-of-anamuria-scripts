using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementsDecorator : MonoBehaviour
{
    public PropType[] decorateObjects;
  //  public PropType landOfSettlement;
    public TilePropContainer envManager;
    public int howManyEnvTotal;

    public void GenerateEnvironmentForTile(TerrainTypeContainer container)
    {
        int rndPropToSpawn = Random.Range(1, 5);
        for (int i = 0; i < rndPropToSpawn; i++)
        {
            int rndForObjectToDecorateWith = Random.Range(0, decorateObjects.Length);
            GameObject temp =Instantiate( envManager.GetProp(decorateObjects[rndForObjectToDecorateWith]));
           container.SetGameObjectToCorner( temp);
          //  temp = Instantiate(envManager.GetProp(landOfSettlement));
          //  container.SetLand(temp);
        }
    }
}
