using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPoke : Enemy
{
    [SerializeField] float _slowAmount = 0.1f;

    protected override void PlayerImpact(Player player)
    {
        //base.PlayerImpact(player);
        if (player != null)
        {
            TankController tankController = player.GetComponent<TankController>();
            if (tankController != null)
            {
                tankController.MaxSpeed -= _slowAmount;
            }
        }
    }
}
