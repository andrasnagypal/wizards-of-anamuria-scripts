using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureData 
{
    public CreatureType typeOfCreature;
    public string createId;
    public int currentHealth,maxHealth, lvlOfCreature, manaForCreature,dmgPerHit;
    public float attackSpeed;
    public GameObject targetToAttack;
    public int[] theTileIndexesTheCreatureIsOn;
}
