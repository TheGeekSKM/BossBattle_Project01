using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BasicGun : ProjectileGunBase
{
    [SerializeField] TextMeshProUGUI ammoCountText;

    protected override void MyInput()
    {
        base.MyInput();
    }

    protected override void Update()
    {
        base.Update();
        if (ammoCountText != null)
        {
            ammoCountText.text = "" + BulletsNumber;
        }
    }


}
