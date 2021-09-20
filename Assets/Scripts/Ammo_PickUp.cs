using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_PickUp : CollectibleBase
{
    protected override void Collect(Player player)
    {
        //throw new System.NotImplementedException();
        player.PlayerGun.AddAmmo();
        
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(GetComponent<Rigidbody>().rotation * turnOffset);

        Vector3 moveOffset = new Vector3(0, 0, (-1 * MoveSpeed));
        rb.MovePosition(GetComponent<Rigidbody>().position + moveOffset);
    }
}
