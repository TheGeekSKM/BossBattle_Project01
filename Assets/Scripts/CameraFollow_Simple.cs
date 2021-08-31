using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Simple : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] public float yHeightAboveTank = 10f;

    [SerializeField] public Transform playerTransform;


    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}
