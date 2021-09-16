using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [Header("Location Transforms")]
    [SerializeField] Transform leftMostPoint;
    [SerializeField] Transform rightMostPoint;

    [Header("Spawner Options")]
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;

    [Header("Objects to Spawn")]
    [SerializeField] List<GameObject> spawningList = new List<GameObject>();

    //private variables
    bool equalZValues;

    private void Awake()
    {
        if (leftMostPoint.position.z == rightMostPoint.position.z)
        {
            equalZValues = true;
        }
        else
        {
            equalZValues = false;
        }
    }

    private void Update()
    {
        if (Time.time >= _timeToSpawn)
        {
            Spawn();
            _timeToSpawn = Time.time + _timeBetweenWaves;
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, spawningList.Count - 1);

        //This basically spawns an object at a random index from the list above and spawns it at a random x and z value that lies between the LeftMost and RightMost points
        Instantiate(spawningList[randomIndex], new Vector3(Random.Range(leftMostPoint.position.x, rightMostPoint.position.x), 1f, Random.Range(leftMostPoint.position.z, rightMostPoint.position.z)), Quaternion.identity);
    }
}
