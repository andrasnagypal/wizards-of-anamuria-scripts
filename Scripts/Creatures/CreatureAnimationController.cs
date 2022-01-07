using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimationController : MonoBehaviour
{
    Animator theCreatureAnimator;

    private void Awake()
    {
        theCreatureAnimator = GetComponentInChildren<Animator>();
    }

    public void SetWalkingAnimationForCreature(CreatureType creature)
    {
        switch (creature)
        {
            case CreatureType.Druid:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.Knight:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.Elf:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.Wolf:
                {
                    theCreatureAnimator.Play("Run Forward WO Root 0");
                }
                break;
            case CreatureType.Bandit:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.Cobra:
                {
                    theCreatureAnimator.Play("Slither Forward WO Root 0");
                }
                break;
            case CreatureType.Golem:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.AncientWarrior:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
                }
                break;
            case CreatureType.Spider:
                break;
            case CreatureType.Orc:
                {
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
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
                    theCreatureAnimator.Play("UD_infantry_06_combat_walk");
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
        }
    }

        public void SetAttackingAnimationForCreature(CreatureType creature)
        {
            switch (creature)
            {
                case CreatureType.Druid:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.Knight:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.Elf:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.Wolf:
                {
                    theCreatureAnimator.Play("Bite Attack 0");
                }
                break;
                case CreatureType.Bandit:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.Cobra:
                {
                    theCreatureAnimator.Play("Bite Attack 0");
                }
                break;
                case CreatureType.Golem:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.AncientWarrior:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
                }
                break;
                case CreatureType.Spider:
                    break;
                case CreatureType.Orc:
                {
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
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
                    theCreatureAnimator.Play("UD_infantry_07_attack_A");
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
            }

        }
    public void SetIdlingAnimationForCreature(CreatureType creature)
    {
        switch (creature)
        {
            case CreatureType.Druid:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.Knight:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.Elf:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.Wolf:
                {
                    theCreatureAnimator.Play("Idle 0");
                }
                break;
            case CreatureType.Bandit:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.Cobra:
                {
                    theCreatureAnimator.Play("Idle 0");
                }
                break;
            case CreatureType.Golem:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.AncientWarrior:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
                }
                break;
            case CreatureType.Spider:
                break;
            case CreatureType.Orc:
                {
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
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
                    theCreatureAnimator.Play("UD_infantry_05_combat_idle");
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
        }

    }

    public void SetDyingAnimationForCreature(CreatureType creature)
    {
        switch (creature)
        {
            case CreatureType.Druid:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.Knight:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.Elf:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.Wolf:
                {
                    theCreatureAnimator.Play("Die");
                }
                break;
            case CreatureType.Bandit:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.Cobra:
                {
                    theCreatureAnimator.Play("Die");
                }
                break;
            case CreatureType.Golem:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.AncientWarrior:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
                }
                break;
            case CreatureType.Spider:
                break;
            case CreatureType.Orc:
                {
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
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
                    theCreatureAnimator.Play("UD_infantry_10_death_A");
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
        }
    }
}