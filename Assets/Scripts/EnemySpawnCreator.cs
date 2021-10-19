using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawnCreator : EditorWindow
{
    //Window Variables
    Rect settingsRect;
    Rect createRect;

    Texture2D settingsTex;
    Texture2D createTex;

    
    //Variables
    GameObject enemySpawnerObject;
    GameObject storedObject;
    float _timeToSpawn = 2f;
    float _timeBetweenWaves = 0.7f;


    // [MenuItem("Window/Enemy Spawn Creator")]
    static void OpenWindow()
    {
        EnemySpawnCreator window = (EnemySpawnCreator)GetWindow(typeof(EnemySpawnCreator));
        window.minSize = new Vector2(200, 500);
        window.Show();
    }

    void InitData()
    {
        settingsTex = Resources.Load<Texture2D>("settingsTex");
        createTex = Resources.Load<Texture2D>("createTex");

        settingsRect = new Rect(0, 0, (Screen.width), (Screen.height * 0.75f));
        createRect = new Rect(0, (Screen.height * 0.75f), Screen.width, Screen.height);
    }

    void OnEnable()
    {

        InitData();

        enemySpawnerObject = Resources.Load<GameObject>("EnemySpawner");
        enemySpawnerObject.GetComponent<EnemySpawnManager>().TimeToSpawn = _timeToSpawn;
        enemySpawnerObject.GetComponent<EnemySpawnManager>().TimeBetweenWaves = _timeBetweenWaves;
    }

    void OnGUI()
    {
        settingsRect = new Rect(0, 0, (Screen.width), (Screen.height * 0.75f));
        createRect = new Rect(0, (Screen.height * 0.75f), Screen.width, Screen.height);

        GUI.DrawTexture(settingsRect, settingsTex);
        GUI.DrawTexture(createRect, createTex);

        GUILayout.BeginArea(settingsRect);

            EditorGUILayout.BeginHorizontal();

            GUILayout.Label("Wait time before spawning commences:");
            _timeToSpawn = (float)EditorGUILayout.FloatField(_timeToSpawn);
        
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

            GUILayout.Label("Wait time between waves:");
            _timeBetweenWaves = (float)EditorGUILayout.FloatField(_timeBetweenWaves);
        
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();


        GUILayout.BeginArea(createRect);
            
            GUILayout.Label("Click here to create the Spawner:");
            if (GUILayout.Button("Create"))
            {
                enemySpawnerObject.transform.position = new Vector3(0f, 3f, 0f);
                enemySpawnerObject.GetComponent<EnemySpawnManager>().TimeToSpawn = _timeToSpawn;
                enemySpawnerObject.GetComponent<EnemySpawnManager>().TimeBetweenWaves = _timeBetweenWaves;
                storedObject = Instantiate(enemySpawnerObject, Vector3.zero, Quaternion.identity);
            
            }

            GUILayout.Label("Click here to remove the Spawner:");
            if (GUILayout.Button("Remove") && storedObject != null)
            {
                DestroyImmediate(storedObject);
                
            }

        GUILayout.EndArea();

        
    }
}
