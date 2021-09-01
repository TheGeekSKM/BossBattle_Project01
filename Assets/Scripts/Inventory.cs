using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //variables
    public List<TreasureScript> coinCollection = new List<TreasureScript>();

    public int getCoinAmount()
    {
        return coinCollection.Count;
    }

    public void addItem(TreasureScript treasureItem)
    {
        coinCollection.Add(treasureItem);
        Debug.Log("CoinCollection_Count: " + coinCollection.Count);
    }
}
