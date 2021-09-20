using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectibleBase
{
    [SerializeField] int _healingAmount = 1;
    public int HealingAmount
    {
        get
        {
            return _healingAmount;
        }
        set
        {
            _healingAmount = value;
        }
    }

    protected override void Collect(Player player)
    {
        //throw new System.NotImplementedException();
        player.PlayerHealth.Healing(_healingAmount);
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(2, MovementSpeed, 2);
        rb.MoveRotation(GetComponent<Rigidbody>().rotation * turnOffset);

        Vector3 moveOffset = new Vector3(0, 0, (-1 * MoveSpeed));
        rb.MovePosition(GetComponent<Rigidbody>().position + moveOffset);
    }
}
