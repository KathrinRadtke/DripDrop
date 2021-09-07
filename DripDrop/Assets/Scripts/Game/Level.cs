using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private float endPosition;
    [SerializeField] private float movementTime;

    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private int collectableCount = 50;
    
    void Start()
    {
        cameraMovement.SetLevelSettings(endPosition, movementTime);
        StartCoroutine(WaitForLevelGeneration());
    }

    private IEnumerator WaitForLevelGeneration()
    {
        yield return StartCoroutine(levelGenerator.GenerateLevel(collectableCount, 0, endPosition));
        cameraMovement.StartLevel();
    }

}
