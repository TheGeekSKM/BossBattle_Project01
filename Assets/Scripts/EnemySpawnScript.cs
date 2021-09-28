using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnScript : MonoBehaviour
{
    [Header("Location Transforms")]
    [SerializeField] Transform leftMostPoint;
    [SerializeField] Transform rightMostPoint;
    [SerializeField] GameObject _bossMonster;

    [Header("Spawner Options")]
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 0.5f;
    BossMonster boss;
    

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

        boss = _bossMonster.GetComponent<BossMonster>();
    }

    private void Update()
    {


        if (boss != null)
        {
            if (boss.PhaseTwo)
            {
                leftMostPoint.transform.position = new Vector3(-34.4f, 0f, 36.1f);
                rightMostPoint.transform.position = new Vector3(34.4f, 0f, 36.1f);
                _timeBetweenWaves = 0.3f;
            }

            if (Time.time >= _timeToSpawn)
            {
                Spawn();
                _timeToSpawn = Time.time + _timeBetweenWaves;
            }
        }

        
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, spawningList.Count - 1);

        //This basically spawns an object at a random index from the list above and spawns it at a random x and z value that lies between the LeftMost and RightMost points
        Instantiate(spawningList[randomIndex], new Vector3(Random.Range(leftMostPoint.position.x, rightMostPoint.position.x), 1f, Random.Range(leftMostPoint.position.z, rightMostPoint.position.z)), Quaternion.identity);
    }
}
