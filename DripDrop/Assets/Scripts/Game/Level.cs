using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private float endPosition;
    [SerializeField] private float movementTime;
    
    void Start()
    {
        Camera.main.GetComponent<CameraMovement>(). SetLevelSettings(endPosition, movementTime);
    }
    
    
    
}
