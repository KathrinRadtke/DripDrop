using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameOver gameOverScreen;
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private Player player;

    private bool[] levelsAccessible = new bool[4];

    private void Awake()
    {
        SetLevelAccessible(0, true);
    }

    public void SelectLevel(int levelIndex)
    {
        Fade.DoFade(0.5f, 0.3f, 0.5f);
        SoundSystem.Instance().PlaySound("plop");
        level.StartLevelGeneration(levelIndex);
        player.ResetSize();
        Fade.OnFadedOut += OnFadedOut;
        Fade.OnFadeComplete += OnFadeComplete;
    }

    private void OnFadedOut()
    {
        Fade.OnFadedOut -= OnFadedOut;
        mainMenu.SetActive(false);
    }

    private void OnFadeComplete()
    {
        level.StartLevel();
    }

    public void SetLevelAccessible(int levelIndex, bool accessible)
    {
        if (levelIndex <= 3)
        {
            levelsAccessible[levelIndex] = accessible;
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = levelsAccessible[i];
        }
    }

    public void ShowGameOverScreen(bool unlocked)
    {
        gameOverScreen.Show(unlocked);
    }
}
