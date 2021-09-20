using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject debugModePanel;
    [SerializeField] TextMeshProUGUI debugSpawnText;

    [Header("Spawning References")]
    [SerializeField] GameObject healthIncrease;

    //Private Variables
    bool debugMode;
    bool spawnHealthIncrease;
    string neutralText;

    private void Awake()
    {
        debugModePanel.SetActive(false);
        debugMode = false;
        spawnHealthIncrease = true;
        neutralText = "N/A";
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (spawnHealthIncrease && debugMode)
            {
                Instantiate(healthIncrease, new Vector3(0f, 0.5f, 20f), Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            debugMode = !debugMode;
        }

        if (debugMode)
        {
            DebugVisualsOn();
        }
        else
        {
            DebugVisualsOff();
        }

        if (spawnHealthIncrease && debugSpawnText != null)
        {
            debugSpawnText.text = "Health Increase";
        }
        else if (!spawnHealthIncrease && debugSpawnText!= null)
        {
            debugSpawnText.text = neutralText;
        }


        //HealthIncrease
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            spawnHealthIncrease = !spawnHealthIncrease;
        }
    }

    private void DebugVisualsOn()
    {
        debugModePanel.SetActive(true);
    }

    private void DebugVisualsOff()
    {
        debugModePanel.SetActive(false);
    }
}
