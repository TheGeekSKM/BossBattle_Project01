using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BossMonster : Enemy
{
    [Header("References")]
    [SerializeField] bool _phaseTwo = false;
    [SerializeField] Health _bossHealth;
    [SerializeField] Animation bossAnim;
    [SerializeField] Animator bossAnim2;


    Vector3 startPosition;
    Vector3 endPostion;
    float movementDuration = 50f;
    float elapsedTime;

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
        bossAnim.enabled = false;
        bossAnim2.enabled = false;
        startPosition = transform.position;

        elapsedTime += Time.deltaTime;
        float completed = elapsedTime / movementDuration;

        transform.position = Vector3.Lerp(startPosition, new Vector3(0f, 0f, 18f), completed);
    }
}
