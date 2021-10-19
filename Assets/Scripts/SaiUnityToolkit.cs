using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaiUnityToolkit : EditorWindow
{

    //Window Variables
    Rect headerRect;
    Rect lerpMenuRect;
    Rect enemySpawnerMenuRect;

    Texture2D headerTex;
    Texture2D lerpMenuTex;
    Texture2D enemySpawnerMenuTex;


    [MenuItem("Window/Sai's Toolkit")]
    static void OpenWindow()
    {
        SaiUnityToolkit window = (SaiUnityToolkit)GetWindow(typeof(SaiUnityToolkit));
        window.minSize = new Vector2(350, 500);

        window.Show();
    }

    void InitData()
    {
        headerRect = new Rect(0, 0, Screen.currentResolution.width, 50);
        lerpMenuRect = new Rect(0, 50, (Screen.currentResolution.width / 2), Screen.currentResolution.height);
        enemySpawnerMenuRect = new Rect((Screen.currentResolution.width / 2), 50, Screen.currentResolution.width, Screen.currentResolution.height);

        headerTex = Resources.Load<Texture2D>("headerBackgroundTex");

        lerpMenuTex = Resources.Load<Texture2D>("lerpBackgroundTex");

        enemySpawnerMenuTex = Resources.Load<Texture2D>("enemyBackgroundTex");


    }

    void OnEnable()
    {
        InitData();
    }

    void OnGUI()
    {
        headerRect = new Rect(0, 0, Screen.width, 75);
        lerpMenuRect = new Rect(0, 75, (Screen.width / 2), Screen.height);
        enemySpawnerMenuRect = new Rect((Screen.width / 2), 75, Screen.width, Screen.height);

        GUI.DrawTexture(headerRect, headerTex);
        GUI.DrawTexture(lerpMenuRect, lerpMenuTex);
        GUI.DrawTexture(enemySpawnerMenuRect, enemySpawnerMenuTex);

        

        GUILayout.BeginArea(headerRect);

            GUILayout.Label("WELCOME TO SAI'S UNITY TOOLKIT");
            GUILayout.Label("A collection of tools that no one else made for free, ");
            GUILayout.Label("so Sai made them himself.");

        GUILayout.EndArea();

        GUILayout.BeginArea(lerpMenuRect);


           
            GUILayout.Label("Click here to open the Lerp Menu");
            if (GUILayout.Button("Lerp Creator"))
            {
                LerpEditorScript lerpWindow = (LerpEditorScript)GetWindow(typeof(LerpEditorScript));
                lerpWindow.Show();  
            }     
            
        

        GUILayout.EndArea();

        GUILayout.BeginArea(enemySpawnerMenuRect);


           
            GUILayout.Label("Click here to open the Enemy Spawner Menu");
            if (GUILayout.Button("Enemy Spawner Creator"))
            {
                EnemySpawnCreator enemyWindow = (EnemySpawnCreator)GetWindow(typeof(EnemySpawnCreator));
                enemyWindow.Show();  
            }     
            
        

        GUILayout.EndArea();
    }
}
