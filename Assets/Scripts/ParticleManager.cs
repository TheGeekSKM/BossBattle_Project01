using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] float decayTime = 3f;

    private void Awake()
    {
        Destroy(gameObject, decayTime);
    }

    
}
