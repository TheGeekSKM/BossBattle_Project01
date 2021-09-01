using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration = 3f;
    protected float PowerUpDuration => _powerUpDuration;

    [SerializeField] float _movementSpeed = 3f;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _powerUpParticles;
    [SerializeField] AudioClip _powerUpSoundEffects;

    Rigidbody _rB;
    MeshRenderer _powerUpRenderer;
    BoxCollider _powerUpCollider;

    private void Awake()
    {
        _rB = GetComponent<Rigidbody>();
        _powerUpRenderer = GetComponent<MeshRenderer>();
        _powerUpCollider = GetComponent<BoxCollider>();

    }

    private void FixedUpdate()
    {
        Movement(_rB);
    }

    protected virtual void Movement(Rigidbody rbNew)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rbNew.MoveRotation(_rB.rotation * turnOffset);
    }

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            StartCoroutine(PowerUpTimer(_powerUpDuration, player));
            gameObject.SetActive(false);

        }
    }

    IEnumerator PowerUpTimer(float duration, Player player)
    {
        PowerUp(player);
        _powerUpRenderer.enabled = false;
        _powerUpCollider.enabled = false;
        yield return new WaitForSeconds(_powerUpDuration);
        PowerDown(player);
    }
}
