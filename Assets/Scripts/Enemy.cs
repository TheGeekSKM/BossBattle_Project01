
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    //Variables
    [SerializeField] int _damageAmount = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;
    [SerializeField] float _moveSpeed = .15f;
    protected float MoveSpeed => _moveSpeed;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();

            gameObject.SetActive(false);
        }
    }

    protected virtual void PlayerImpact(Player player)
    {
        player.DecreaseHealth(_damageAmount);
    }

    private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }

        //audio
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }


    }

    protected virtual void Move()
    {
        Vector3 moveOffset = new Vector3(0, 0, (-1 * _moveSpeed)) ;
        _rb.MovePosition(_rb.position + moveOffset);
    }
}
