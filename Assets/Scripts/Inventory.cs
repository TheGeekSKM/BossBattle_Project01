using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //variables
    [Header("Variables")]
    public List<TreasureScript> coinCollection = new List<TreasureScript>();
 

    [Header("References")]
    [SerializeField] TextMeshProUGUI coinText;
   

   

    public int getCoinAmount()
    {
        return coinCollection.Count;
    }

    public void addItem(TreasureScript treasureItem)
    {
        coinCollection.Add(treasureItem);
        coinText.text = "" + coinCollection.Count;
        Debug.Log("CoinCollection_Count: " + coinCollection.Count);
    }

    
}
