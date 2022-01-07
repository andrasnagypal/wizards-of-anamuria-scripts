using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureManager : MonoBehaviour
{
    public GameObject[] creaturePrefabs;

    public Sprite[] creaturePortraits;


    public GameObject GetPrefab(CreatureType prefabType)
    {
        GameObject temp = null;

        for (int i = 0; i < creaturePrefabs.Length; i++)
        {
          if(  creaturePrefabs[i].GetComponent<CreatureController>().TheCreature==prefabType)
            {
                temp = Instantiate(creaturePrefabs[i]);
                temp.transform.SetParent(transform);
                break;
            }
        }

        return temp;
    }

    public Sprite GetCreaturePortraitForUI(CreatureType creature)
    {
        Sprite temp=null;
        switch ((creature)
)
        {
            case CreatureType.Druid:
                {
                    temp = creaturePortraits[3];
                }
                break;
            case CreatureType.Knight:
                {
                    temp = creaturePortraits[6];
                }
                break;
            case CreatureType.Elf:
                {
                    temp = creaturePortraits[4];
                }
                break;
            case CreatureType.Wolf:
                {
                    temp = creaturePortraits[9];
                }
                break;
            case CreatureType.Bandit:
                {
                    temp = creaturePortraits[1];
                }
                break;
            case CreatureType.Cobra:
                {
                    temp = creaturePortraits[2];
                }
                break;
            case CreatureType.Golem:
                {
                    temp = creaturePortraits[5];
                }
                break;
            case CreatureType.AncientWarrior:
                {
                    temp = creaturePortraits[0];
                }
                break;
            case CreatureType.Spider:
                break;
            case CreatureType.Orc:
                {
                    temp = creaturePortraits[7];
                }
                break;
            case CreatureType.Undead:
                break;
            case CreatureType.DarkElf:
                break;
            case CreatureType.Assassin:
                break;
            case CreatureType.Viking:
                {
                    temp = creaturePortraits[8];
                }
                break;
            case CreatureType.Dragon:
                break;
            case CreatureType.King:
                break;
            case CreatureType.OrcChief:
                break;
            case CreatureType.VikingLeader:
                break;
            case CreatureType.Witch:
                break;
            case CreatureType.BarbarianChief:
                break;
            case CreatureType.AncientQueen:
                break;
            default:
                break;
        }
        return temp;
    }

}
