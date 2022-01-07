using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAlerterController : MonoBehaviour
{
    public Collider boxCollider;
   // public GameObject theGraphics;
    public int[] indexes;

    //public void ActivateUI()
    //{
    //    boxCollider.enabled = false;
    //    if(PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn!=null)
    //    {
    //        FindObjectOfType<CombatArenaManager>().SwitchBattleAlerter(PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn);
    //        PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn = null;
    //        FindObjectOfType<UIManager>().ClosePanel(LayoutType.CombatPanel);
    //    }

    //    PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn = indexes;

    //    FindObjectOfType<UIManager>().SwitchPanel(LayoutType.CombatPanel);
    //    FindObjectOfType<CombatArenaManager>().SwitchBattleAlerter(indexes);


    //}

   


    private void OnMouseDown()
    {
        //ActivateUI();
    }
}
