using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    //Variables
    [SerializeField] float _damageAmount;
    [SerializeField] float _explosionRadius;
    [SerializeField] ParticleSystem _explosionParticle;
    [SerializeField] AudioClip _bulletSoundEffect;

    //Properties
    protected float DamageAmount
    {
        get
        {
            return _damageAmount;
        }
        set
        {
            _damageAmount = value;
        }
    }

    protected float ExplosionRadius
    {
        get
        {
            return _explosionRadius;
        }
        set
        {
            _explosionRadius = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health target = other.gameObject.GetComponent<Health>();
        if (target != null)
        {
            Feedback();
            Damage(target);
            gameObject.SetActive(false);
        }


    }

    private void Update()
    {
        if (transform.position.z > 50 || transform.position.z < -50 || transform.position.x > 75 || transform.position.x < -75)
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void Feedback()
    {
        Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        if (_bulletSoundEffect != null)
        {
            AudioHelper.PlayClip2D(_bulletSoundEffect, 1f);
        }
    }

    protected virtual void Damage(Health entity)
    {
        entity.TakeDamage(3);
    }


}
