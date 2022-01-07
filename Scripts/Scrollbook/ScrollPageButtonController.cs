using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPageButtonController : MonoBehaviour
{
    public Image artForSpell;
    public Sprite artFromScroll;
    public string description;
    public int cost, amount;

  public void RefreshArt()
    {
        artForSpell.sprite = artFromScroll;
    }
}
