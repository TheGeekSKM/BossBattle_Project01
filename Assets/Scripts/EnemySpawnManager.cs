using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Location Transforms")]
    [SerializeField] Transform firstPoint;
    [SerializeField] Transform secondPoint;


    [Header("Spawner Options")]
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 0.5f;
    
    

    [Header("Objects to Spawn")]
    [SerializeField] List<GameObject> spawningList = new List<GameObject>();

    public Transform FirstPoint
    {
        get
        {
            return firstPoint;
        }
        set
        {
            firstPoint = value;
        }
    }

    public Transform SecondPoint
    {
        get
        {
            return secondPoint;
        }
        set
        {
            secondPoint = value;
        }
    }
    public float TimeToSpawn
    {
        get
        {
            return _timeToSpawn;
        }
        set
        {
            _timeToSpawn = value;
        }
    }

    public float TimeBetweenWaves
    {
        get
        {
            return _timeBetweenWaves;
        }
        set
        {
            _timeBetweenWaves = value;
        }
    }
    


    //private variables
    bool equalZValues;

    private void Awake()
    {
        if (firstPoint.position.z == secondPoint.position.z)
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

        //This basically spawns an object at a random index from the list above and spawns it at a random x, y, and z value that lies between the LeftMost and RightMost points
        Instantiate(spawningList[randomIndex], new Vector3(Random.Range(firstPoint.position.x, secondPoint.position.x), Random.Range(firstPoint.position.y, secondPoint.position.y), Random.Range(firstPoint.position.z, secondPoint.position.z)), Quaternion.identity);
    }


    

}
