
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
    [SerializeField] float _zValueToDespawn = -30f;
    protected float MoveSpeed => _moveSpeed;

    [SerializeField] Rigidbody _rb;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (transform.position.z <= _zValueToDespawn)
        {
            Despawn();
        }
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.GetComponent<Health>())
        {
            ObjectImpact(collidedObject);
            ImpactFeedback();

            Despawn();
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    protected virtual void ObjectImpact(GameObject gameColl)
    {
        if (gameColl.GetComponent<Health>())
        {
            Health objectHealth = gameColl.GetComponent<Health>();
            objectHealth.TakeDamage(_damageAmount);
        }
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
