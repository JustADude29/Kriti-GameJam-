using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct items
{
    public string itemName;
    public int index;
    public float price;
    public int buyLimit;
    public bool isCrop;
    public float growthTime;
}



public class ItemVariables : MonoBehaviour
{

    public items[] Items;
}
