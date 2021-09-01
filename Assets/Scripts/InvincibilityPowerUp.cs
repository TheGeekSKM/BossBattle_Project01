using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PowerUpBase
{
       

    protected override void PowerUp(Player player)
    {
        player.ChangeColor(new Color(100, 0, 0));
        player.isInvincible = true;
        Debug.Log("Invincible");
    }

    protected override void PowerDown(Player player)
    {
        player.isInvincible = false;
        player.RevertColor();
        Debug.Log("Not Invincible");
    }

    protected override void Movement(Rigidbody rbNew)
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, 0, MovementSpeed);
        rbNew.MoveRotation(GetComponent<Rigidbody>().rotation * turnOffset);
    }
}
