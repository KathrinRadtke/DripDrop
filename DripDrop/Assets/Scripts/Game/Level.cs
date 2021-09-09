using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private CameraMovement cameraMovement;

    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelBackgrounds levelBackgrounds;

    [SerializeField] private LevelSettings[] levelSettings;

    private int currentLevel;

    public void StartLevelGeneration(int levelIndex)
    {
        currentLevel = levelIndex;
        levelBackgrounds.SetLevelBackground(currentLevel);
        cameraMovement.SetLevelSettings(levelSettings[currentLevel].endPosition, levelSettings[currentLevel].movementTime);
        cameraMovement.OnLevelComplete += OnLevelComplete;
        StartCoroutine(WaitForLevelGeneration());
    }

    public void StartLevel()
    {
        cameraMovement.StartLevel();
    }

    private void ResetLevel()
    {
        cameraMovement.ResetPositions();
        levelGenerator.ResetLevel();
    }

    private IEnumerator WaitForLevelGeneration()
    {
        yield return StartCoroutine(levelGenerator.GenerateLevel(levelSettings[currentLevel].collectableCount, 0, levelSettings[currentLevel].endPosition));
    }

    private void OnLevelComplete()
    {
        ResetLevel();

        cameraMovement.OnLevelComplete -= OnLevelComplete;
        game.SetLevelAccessible(currentLevel + 1, true);
        game.ShowGameOverScreen(true);
        
        SoundSystem.Instance().PlaySound("plop");
    }

    public void GameOver()
    {
        ResetLevel();

        cameraMovement.OnLevelComplete -= OnLevelComplete;
        cameraMovement.Stop();
        game.ShowGameOverScreen(false);
    }
}
