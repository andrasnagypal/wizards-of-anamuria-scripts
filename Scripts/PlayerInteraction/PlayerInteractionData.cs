using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionData : MonoBehaviour
{
    public static int[] battleAlerterIndexesThePlayerClickedOn;

    private void Awake()
    {
        battleAlerterIndexesThePlayerClickedOn = null;
    }
}
