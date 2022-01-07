using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollType:byte
{
    //Arcane
    Runereading,
    ArcaneOrbs,
    ArcaneSeeking,
    ArcaneBubble,
    ArcaneMirror,
    ArcaneFlash,
    //Destruction
    Fireball,
    SparklingSkin,
    FreezingWind,
    Explosion,
    FogOfDecay,
    Vaporize,
    //Protection
    Rejuvenation,
    Shield,
    Focus,
    LightOfInnocence,
    Unbreakable,
    Ascension,
    //Mysticism
    Curse,
    Charm,
    FarSight,
    Paralyze,
    MindReading,
    Invisibility,
    //Conjuring
    SummonArtifact,
    SummonScroll,
    SummonSpellstones,
    SummonBuilding,
    SummonSpirit,
    SummonPortal,
    //Alchemy
    HealingPotion,
    ManaPotion,
    StoneGrowing,
    PotionOfMutation,
    PotionOfConcentration,
    PotionOfTime,
    //Dark Magic
    SoulCollecting,    
    WhispersOfEvil,
    GutWrench,
    LifeDrain,
    CallOfTheUnderworld,
    Vampire,
    DruidScroll,
    KnightScroll,
    ElfScroll,
    WolfScroll,
    BanditScroll,
    CobraScroll,
    GolemScroll,
    AncientWarriorScroll,
    SpiderScroll,
    OrcScroll,
    UndeadScroll,
    DarkElfScroll,
    AssassinScroll,
    VikingScroll,
    OlderScroll
}

public class ScrollbookManager : MonoBehaviour
{
    public  Dictionary<ScrollType, int> scrollbookKnowledge = new Dictionary<ScrollType, int>();
    public List<ScrollDataSO> scrollsData = new List<ScrollDataSO>();
   

    private void Awake()
    {
        for (int i = 0; i < (int)ScrollType.OlderScroll + 1; i++)
        {
            scrollbookKnowledge.Add((ScrollType)i, 0);
        }
        
    }


    public void PlayerChoseThisScroll(ScrollType scroll)
    {
        if (scrollbookKnowledge[scroll]==0)
        {
            //Add available scrollTo page
        }
        scrollbookKnowledge[scroll]++;
        foreach (ScrollDataSO item in scrollsData)
        {
            if(item.scroll==scroll)
            {
                item.scrollAmountAllTogether++;
                break;
            }
        }
    }

    
   public ScrollDataSO GetDataForScroll(ScrollType scroll)
    {
        ScrollDataSO temp=null;
        foreach (ScrollDataSO item in scrollsData)
        {
            if (item.scroll == scroll)
            {
                temp = item;
                break;
            }
        }
        return temp;
    }
}
