using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossMonster : Enemy
{
    [Header("References")]
    [SerializeField] bool _phaseTwo = false;
    [SerializeField] Health _bossHealth;
    [SerializeField] Animation bossAnim;
    [SerializeField] Animator bossAnim2;
    [SerializeField] Transform playerTransform;
    [SerializeField] float timeBetweenMissiles = 3f;
    [SerializeField] GameObject bossProjectile;
    [SerializeField] float rotationSpeed = 2f;

    bool attacked = false;

    Vector3 startPosition;
    Vector3 endPostion;
    float movementDuration = 50f;
    float elapsedTime;

    public event Action PhaseTwoEvent = delegate { };

    #region Properties
    public bool PhaseTwo
    {
        get
        {
            return _phaseTwo;
        }
        set
        {
            _phaseTwo = value;
        }
    }
    public Health BossHealth
    {
        get
        {
            return _bossHealth;
        }
        set
        {
            _bossHealth = value;
        }
    }
    public float TimeBetweenMissiles
    {
        get
        {
            return timeBetweenMissiles; 
        }
        set
        {
            timeBetweenMissiles = value;
        }
    }
    #endregion

    private void Awake()
    {

    }

    private void Update()
    {
        if (_bossHealth.CurrentHealth < (_bossHealth.MaxHealth / 2))
        {
            _phaseTwo = true;

        }
        else
        {
            _phaseTwo = false;
        }

        if (_phaseTwo)
        {
            BossPhaseTwo();

        }
    }

    protected override void Move()
    {

    }

    void BossPhaseTwo()
    {
        PhaseTwoEvent?.Invoke();
        bossAnim.enabled = false;
        bossAnim2.enabled = false;
        startPosition = transform.position;

        elapsedTime += Time.deltaTime;
        float completed = elapsedTime / movementDuration;

        transform.position = Vector3.Lerp(startPosition, new Vector3(0f, 0f, 18f), completed);

        AttackPlayer();
    }

    private void AttackPlayer()
    {
        transform.LookAt(playerTransform.position);

        if (!attacked)
        {
            Rigidbody projectileRB = Instantiate(bossProjectile, new Vector3(transform.position.x, playerTransform.position.y, transform.position.z), Quaternion.identity).GetComponent<Rigidbody>();
            projectileRB.AddForce(transform.forward * 20f, ForceMode.Impulse);
            
            

            attacked = true;
            Invoke(nameof(ResetAttack), timeBetweenMissiles);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

   
}
