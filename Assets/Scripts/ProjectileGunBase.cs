using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGunBase : MonoBehaviour
{
    //before I begin, I want to note that this code was heavily borrowed because I can't figure out Projectile Shooting to save my life
    //because of that, I want to credit the YouTube Channel 'Dave / GameDevelopment' for most of this code. His tutorial can be found
    // at: https://www.youtube.com/watch?v=wZ2UUOC17AY
    // and part 2 at: https://www.youtube.com/watch?v=0jGL5_DFIo8

    //bullet variables
    [Header("Bullet Variables")]
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shootForce;
    [SerializeField] float _upwardForce;

    //bullet Variables properties
    protected GameObject Bullet => _bullet;
    protected float ShootForce => _shootForce;
    protected float UpwardForce => _upwardForce;


    //gun variables
    [Header("Gun Variables")]
    [SerializeField] float _timeBetweenShots;
    [SerializeField] float _spread;
    [SerializeField] float _reloadTime;
    [SerializeField] float _timeBetweenShooting;
    [SerializeField] int _magazineSize;
    [SerializeField] int _bulletsPerTap;
    [SerializeField] bool _allowHold;
    [SerializeField] AudioClip _fireSound;

    //private gun variables
    int bulletsLeft;
    int bulletsShot;

    //more bools
    bool _shooting;
    bool readyToShoot;
    bool reloading;

    //gun variables properties
    protected float TimeBetweenShots => _timeBetweenShots;
    protected float Spread => _spread;
    protected float ReloadTime => _reloadTime;
    protected float TimeBetweenShooting => _timeBetweenShooting;
    protected int MagazineSize => _magazineSize;
    protected int BulletsPerTap => _bulletsPerTap;
    protected bool AllowHold => _allowHold;
    protected bool Shooting
    {
        get 
        {
            return _shooting;
        }
        set
        {
            _shooting = value;
        }
    }

    //References
    [Header("References")]
    [SerializeField] Transform attackPoint;

    //potential bug fixing?
    public bool allowInvoke = true;

    private void Awake()
    {
        bulletsLeft = _magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    protected virtual void MyInput()
    {

        //checking to see if we can hold down to shoot
        if (_allowHold)
        {
            _shooting = Input.GetKey(KeyCode.Space);
        }
        else
        {
            _shooting = Input.GetKeyDown(KeyCode.Space);
        }

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < _magazineSize && !reloading)
        {
            Reloading();
        }

        //reloading automatically
        if (readyToShoot && _shooting && !reloading && bulletsLeft <= 0)
        {
            Reloading();
        }

        //Shooting
        if (readyToShoot && _shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }

    }

    protected virtual void Shoot()
    {
        readyToShoot = false;

        GameObject currentBullet = Instantiate(_bullet, attackPoint.position, Quaternion.identity);
        //currentBullet.transform.forward = attackPoint.transform.forward;

        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * _shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.up * _upwardForce, ForceMode.Impulse);

        if (_fireSound != null)
        {
            AudioHelper.PlayClip2D(_fireSound, 1f);
        }

        bulletsLeft--;
        bulletsShot++;

        //So at this point, Dave does a bunch of RayCast magic to account for FPS Cameras, but since my camera is top down
        // I potentially might not have to worry about that headache.

        if (allowInvoke)
        {
            Invoke("ResetShot", _timeBetweenShooting);
            allowInvoke = false;
        }

        //if you are shooting more than one bullet per tap (like a shotgun)
        if (bulletsShot < _bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", _timeBetweenShots);
        }
    }

    protected virtual void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    protected virtual void Reloading()
    {
        reloading = true;
        Invoke("ReloadFinished", _reloadTime);
    }

    protected virtual void ReloadFinished()
    {
        bulletsLeft = _magazineSize;
        reloading = false;
    }

}
