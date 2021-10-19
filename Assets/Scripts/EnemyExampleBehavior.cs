using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExampleBehavior : MonoBehaviour
{
    //This is just an example class for the enemy. In reality, this object can be replaced with any other object.
    [SerializeField] float _movementSpeed = 3f;

    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }
        set
        {
            _movementSpeed = value;
        }
    }

    
    void Update()
    {
        transform.position += transform.forward * _movementSpeed;

        if (transform.position.x > 40f || transform.position.x < -40f || transform.position.z > 40f || transform.position.z < -40f)
        {
            Destroy(gameObject);
        }
    }
}
