using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class LerpEditorScript : EditorWindow
{

     #region Window Variables
    Texture2D headerSectionTexture;
    Texture2D firstTexture;
    Texture2D secondTexture;
    Texture2D calculateAreaTexture;

    Color headerSectionColor = new Color(0, 0.5f, 1, 0.2f);
    Color firstColor = new Color(0.5f, 0, 1, 0.5f);
    Color secondColor = new Color(1, 0.2f, 0, 0.5f);
    Color calculateAreaColor = new Color(1, 0.92f, 0.016f, 1);

    Rect headerSectionRect;
    Rect firstRect;
    Rect secondRect;
    Rect calculateAreaRect;
     #endregion

     #region Actual Variables
     
     
     Transform firstTransform;
     Transform secondTransform;

     GameObject affectedObject;
     float desiredDuration;
     


     public Transform FirstTransform
     {
          get
          {
               return firstTransform;
          }
          set
          {
               firstTransform = value;
          }
     }
     public Transform SecondTransform
     {
          get
          {
               return secondTransform;
          }
          set
          {
               secondTransform = value;
          }
     }

    

     public float DesiredDuration
     {
          get
          {
               return desiredDuration;
          }
          set
          {
               desiredDuration = value;
          }
     }

     #endregion

    

    

     #region WindowCommands
//     [MenuItem("Window/Lerp")]
     static void OpenWindow()
      {
          LerpEditorScript window = (LerpEditorScript)GetWindow(typeof(LerpEditorScript));
          window.minSize = new Vector2(300, 500);
          window.maxSize = new Vector2(600, 1000);
          window.Show();
      }
     void OnEnable()
     {
          InitTextures();    
          InitData();
          
          
     }
     
     public static void InitData()
     {
          //lerpBehaviour = (LerpBehaviour)ScriptableObject.CreateInstance(typeof(LerpBehaviour));
     }

     void InitTextures()
     {
          headerSectionTexture = new Texture2D(1, 1);
          headerSectionTexture.SetPixel(0, 0, headerSectionColor);
          headerSectionTexture.Apply();
          
          firstTexture = new Texture2D(1, 1);
          firstTexture.SetPixel(0, 0, firstColor);
          firstTexture.Apply();
          
          secondTexture = new Texture2D(1, 1);
          secondTexture.SetPixel(0, 0, secondColor);
          secondTexture.Apply();
          
          calculateAreaTexture = new Texture2D(1, 1);
          calculateAreaTexture.SetPixel(0, 0, calculateAreaColor);
          calculateAreaTexture.Apply();
     }
     void OnGUI()
     {
          DrawLayouts();
          DrawHeader();
          DrawfirstSettings();
          DrawsecondSettings();
          DrawCalculateAreaSettings();
     }

     void DrawLayouts()
     {
          headerSectionRect.x = 0;
          headerSectionRect.y = 0;
          headerSectionRect.width = Screen.width;
          headerSectionRect.height = 50;

          GUI.DrawTexture(headerSectionRect, headerSectionTexture);

          firstRect.x = 0;
          firstRect.y = 50;
          firstRect.width = Screen.width / 2f;
          firstRect.height = Screen.height - 150;

          GUI.DrawTexture(firstRect, firstTexture);

          secondRect.x = Screen.width / 2f;
          secondRect.y = 50;
          secondRect.width = Screen.width / 2f;
          secondRect.height = Screen.height - 150;
       

          GUI.DrawTexture(secondRect, secondTexture);

          calculateAreaRect.x = 0;
          calculateAreaRect.y = Screen.height - 150;
          calculateAreaRect.width = Screen.width;
          calculateAreaRect.height = Screen.height;
            

          GUI.DrawTexture(calculateAreaRect, calculateAreaTexture);




     }
     void DrawHeader()
     {
          GUILayout.BeginArea(headerSectionRect);

          GUILayout.Label("Lerp Menu");
         
          GUILayout.EndArea();
     }

     void DrawfirstSettings()
     {
     GUILayout.BeginArea(firstRect);
               
          GUILayout.Label("First Transform Menu");

          EditorGUILayout.BeginHorizontal();
               
               GUILayout.Label("First Transform");
               firstTransform = (Transform)EditorGUILayout.ObjectField(firstTransform, typeof(Transform), true);
          
          EditorGUILayout.EndHorizontal();

          GUILayout.EndArea();
     }

     void DrawsecondSettings()
     {
          GUILayout.BeginArea(secondRect);
          
          GUILayout.Label("Second Transform Menu");


          EditorGUILayout.BeginHorizontal();
               
               GUILayout.Label("Second Transform");
               secondTransform = (Transform)EditorGUILayout.ObjectField(secondTransform, typeof(Transform), true);
          
          EditorGUILayout.EndHorizontal();

          GUILayout.EndArea();
     }

     void DrawCalculateAreaSettings()
        {
          GUILayout.BeginArea(calculateAreaRect);

          GUILayout.Label("Affected Object Transform Menu");

          EditorGUILayout.BeginHorizontal();
               
               GUILayout.Label("Affected Object");
               affectedObject = (GameObject)EditorGUILayout.ObjectField(affectedObject, typeof(GameObject), true);
               
          
          EditorGUILayout.EndHorizontal();

           EditorGUILayout.BeginHorizontal();

               GUILayout.Label("Desired Duration (seconds)");
               desiredDuration = (float)EditorGUILayout.FloatField(desiredDuration);

          EditorGUILayout.EndHorizontal();


          //button
          if (GUILayout.Button("Set Up"))
          {
               Calculate();
          }

          if (GUILayout.Button("Remove Lerp"))
          {
               RemoveLerp();
          }

          GUILayout.EndArea();
        }
     
     #endregion
   
     #region LerpCalculation

     void Calculate()
     {
          affectedObject.transform.position = firstTransform.position;
          if (!affectedObject.GetComponent<LerpBehaviour>())
          {
               affectedObject.AddComponent<LerpBehaviour>();
          }
          affectedObject.GetComponent<LerpBehaviour>().firstTransform = this.firstTransform;
          affectedObject.GetComponent<LerpBehaviour>().secondTransform = this.secondTransform;
          affectedObject.GetComponent<LerpBehaviour>().movementDuration = this.desiredDuration;
                   
     }

     void RemoveLerp()
     {
          if (affectedObject.GetComponent<LerpBehaviour>())
          {
               LerpBehaviour toBeGone = affectedObject.GetComponent<LerpBehaviour>();
               DestroyImmediate(toBeGone);
          }
     }

     #endregion
}

#region Igonore
// public class TimeSettings : EditorWindow
// {
     

//      public static void OpenWindow()
//      {
//           TimeSettings window = (TimeSettings)GetWindow(typeof(TimeSettings));
//           window.minSize = new Vector2(250, 200);
//           window.Show();
//      }

//      void OnGUI()
//      {
//           EditorGUILayout.BeginHorizontal();

//                GUILayout.Label("Desired Duration (seconds)");
//                desiredDuration = (float)EditorGUILayout.FloatField(desiredDuration);

//           EditorGUILayout.EndHorizontal();
//      }
// }
#endregion
