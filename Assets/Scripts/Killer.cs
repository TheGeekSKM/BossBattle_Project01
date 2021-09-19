using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy
{
    

    protected override void ObjectImpact(GameObject player)
    {
        if (player.GetComponent<Health>())
        {
            Health objectHealth = player.GetComponent<Health>();
            objectHealth.Kill();
        }
    }

   
}
