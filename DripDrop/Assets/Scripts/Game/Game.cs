using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private GameObject mainMenu;

    public void SelectLevel(int levelIndex)
    {
        level.StartLevel(levelIndex);
        mainMenu.SetActive(false);
    }
}
