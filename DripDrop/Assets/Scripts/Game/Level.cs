using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;

    [SerializeField] private LevelGenerator levelGenerator;

    [SerializeField] private LevelSettings[] levelSettings;

    private int currentLevel;

    public void StartLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        cameraMovement.SetLevelSettings(levelSettings[currentLevel].endPosition, levelSettings[currentLevel].movementTime);
        StartCoroutine(WaitForLevelGeneration());
    }

    private IEnumerator WaitForLevelGeneration()
    {
        yield return StartCoroutine(levelGenerator.GenerateLevel(levelSettings[currentLevel].collectableCount, 0, levelSettings[currentLevel].endPosition));
        cameraMovement.StartLevel();
    }

}
