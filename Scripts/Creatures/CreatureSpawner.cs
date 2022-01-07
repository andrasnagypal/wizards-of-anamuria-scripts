using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public int[] indexes;
    public CreatureType TheCreature;
    public bool isMythical = false;
  
    public void SetCreatureTypeBasedOnTerrain()
    {
        int rnd;
        TerrainTypeContainer temp = GetComponentInParent<TerrainTypeContainer>();
        CreatureType[] selection;
        switch (temp.typeOfTerrain)
        {
            case TerrainTypes.Forest:
                {
                     selection = new CreatureType[] { CreatureType.Bandit, CreatureType.Knight, CreatureType.Elf, CreatureType.Wolf, CreatureType.Orc, CreatureType.Druid };
                   
                    rnd = Random.Range(0, selection.Length);
                    TheCreature = selection[rnd];
                }
                break;
            case TerrainTypes.Desert:
                {
                     selection = new CreatureType[] { CreatureType.AncientWarrior, CreatureType.Bandit, CreatureType.Orc, CreatureType.Golem, CreatureType.Cobra };
                    
                    rnd = Random.Range(0, selection.Length);
                    TheCreature = selection[rnd];
                }
                break;
            case TerrainTypes.Frozen:
                {
                     selection = new CreatureType[] { CreatureType.Viking, CreatureType.Bandit, CreatureType.Orc, CreatureType.Golem, CreatureType.Wolf };
                    rnd = Random.Range(0, selection.Length);
                    TheCreature = selection[rnd];
                }
                break;
            case TerrainTypes.Wasteland:
                {
                    selection = new CreatureType[] { CreatureType.Viking, CreatureType.Cobra, CreatureType.Golem, CreatureType.AncientWarrior, CreatureType.Orc };
                    rnd = Random.Range(0, selection.Length);
                    TheCreature = selection[rnd];
                }
                break;
            case TerrainTypes.Mountain:
                {

                }
                break;
            case TerrainTypes.Settlement:
                {
                    selection = new CreatureType[] { CreatureType.Viking,CreatureType.Bandit, CreatureType.Knight, CreatureType.Elf, CreatureType.Wolf, CreatureType.Golem, CreatureType.Druid };
                    rnd = Random.Range(0, selection.Length);
                    TheCreature = selection[rnd];
                }
                break;
            case TerrainTypes.Start:
                {

                }
                break;

            case TerrainTypes.Dungeon:
                break;

        }
    }

    public void SpawnCreature(int[] tileIndexes)
    {
        SetCreatureTypeBasedOnTerrain();
        GameObject creature = FindObjectOfType<CreatureManager>().GetPrefab(TheCreature);
        CreatureController controller = creature.GetComponent<CreatureController>();
        {
            controller.dataForTheCreature = new CreatureData();
            controller.dataForTheCreature.targetToAttack = null;
            controller.dataForTheCreature.createId = gameObject.GetInstanceID().ToString();
            controller.dataForTheCreature.lvlOfCreature = UnityEngine.Random.Range(0, 40);
            int lvlBoundary = controller.dataForTheCreature.lvlOfCreature / 10;
            controller.dataForTheCreature.dmgPerHit = CreatureStats.dmgForLvl[lvlBoundary];
            Debug.Log("Dmg: " + controller.dataForTheCreature.dmgPerHit);
            controller.dataForTheCreature.maxHealth = CreatureStats.healthForLvl[lvlBoundary];
            controller.dataForTheCreature.currentHealth = CreatureStats.healthForLvl[lvlBoundary];
            Debug.Log("Health: " + controller.dataForTheCreature.maxHealth);
            controller.dataForTheCreature.manaForCreature = 10;
            controller.dataForTheCreature.theTileIndexesTheCreatureIsOn = tileIndexes;
            controller.dataForTheCreature.attackSpeed = CreatureStats.attackSpeed[lvlBoundary];
            controller.animationController = creature.GetComponent<CreatureAnimationController>();
            controller.combatController = creature.GetComponent<CreatureCombatController>();
            controller.dataForTheCreature.typeOfCreature = TheCreature;
            if (creature.GetComponent<CreatureMovement>() != null)
            {
                controller.moveController = creature.GetComponent<CreatureMovement>();
            }
        }
       
        creature.transform.position = transform.position;
        FindObjectOfType<CombatArenaManager>().AddParticipantToCombatArea(tileIndexes, creature);
        Destroy(gameObject);
    }


    

    
}
