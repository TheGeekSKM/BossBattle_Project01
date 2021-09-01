using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : CollectibleBase
{
    

    protected override void Collect(Player player)
    {
        //add it to inventory and destroy it as well
        if (player != null)
        {
            player.playerInventory.addItem(this);
            
            gameObject.SetActive(false);
        }

    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, 0, MovementSpeed);
        rb.MoveRotation(GetComponent<Rigidbody>().rotation * turnOffset);
    }
}
