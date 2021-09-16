using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InvincibilityPowerUp : PowerUpBase
{
    [SerializeField] GameObject _invicibilityPanel;

    protected override void PowerUp(Player player)
    {
        player.ChangeColor(new Color(100, 0, 0));
        player.isInvincible = true;
        Debug.Log("Invincible");
        _invicibilityPanel.SetActive(true);
    }

    protected override void PowerDown(Player player)
    {
        player.isInvincible = false;
        player.RevertColor();
        Debug.Log("Not Invincible");
        _invicibilityPanel.SetActive(false);
    }

    protected override void Movement(Rigidbody rbNew)
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, 0, MovementSpeed);
        rbNew.MoveRotation(GetComponent<Rigidbody>().rotation * turnOffset);

        Vector3 moveOffset = new Vector3(0, 0, (-1 * MoveSpeed));
        rbNew.MovePosition(GetComponent<Rigidbody>().position + moveOffset);
    }
}
