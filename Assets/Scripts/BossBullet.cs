using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : BulletBase
{
    [SerializeField] float bulletDecayTime = 3f;

    private void Awake()
    {
        Destroy(gameObject, bulletDecayTime);
    }

   
}
