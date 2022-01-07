using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "RewardOnUI", menuName = "ScriptableObjects/RewardType", order = 2)]
public class RewardSO : ScriptableObject
{
    public RewardType reward;
    public string rewardClass, rewardRank;
    public Sprite imageOfReward;
}
