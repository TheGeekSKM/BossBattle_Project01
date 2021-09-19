using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration = 3f;
    protected float PowerUpDuration => _powerUpDuration;

    [SerializeField] float _movementSpeed = 3f;
    protected float MovementSpeed => _movementSpeed;
    
    [SerializeField] float _moveSpeed = 3f;
    protected float MoveSpeed => _moveSpeed;

    [SerializeField] float zValueToDespawn = -30f;



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

    private void Update()
    {
        if (transform.position.z <= zValueToDespawn)
        {
            gameObject.SetActive(false);
        }
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
            Feedback();
            StartCoroutine(PowerUpTimer(_powerUpDuration, player));
            

        }
    }

    private void Feedback()
    {
        if (_powerUpParticles != null)
        {
            _powerUpParticles = Instantiate(_powerUpParticles, transform.position, Quaternion.identity);
        }
        if (_powerUpSoundEffects)
        {
            AudioHelper.PlayClip2D(_powerUpSoundEffects, 1f);
        }
    }

    IEnumerator PowerUpTimer(float duration, Player player)
    {
        PowerUp(player);
        _powerUpRenderer.enabled = false;
        _powerUpCollider.enabled = false;
        yield return new WaitForSeconds(duration);
        PowerDown(player);
        gameObject.SetActive(false);
    }
}
