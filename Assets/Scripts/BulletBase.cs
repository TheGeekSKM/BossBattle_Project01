﻿using System.Collections;
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
        BossMonster monster = other.gameObject.GetComponent<BossMonster>();
        if (monster != null)
        {
            Feedback();
            Damage();
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

    protected virtual void Damage()
    {
        //need to make a health class first
    }


}
