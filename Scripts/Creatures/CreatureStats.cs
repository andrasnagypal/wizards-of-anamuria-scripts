using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreatureStats 
{
    public static int[] dmgForLvl = new int[10]
    {
     2,4,6,8,10,15,20,25,30,40
    };
    public static int[] healthForLvl = new int[10]
    {
        20,40,60,80,100,150,200,300,400,500
    };
    public static float[] attackSpeed = new float[10]
    {
        1,1,1,1,1,1,1,1,1,1
    };
}
