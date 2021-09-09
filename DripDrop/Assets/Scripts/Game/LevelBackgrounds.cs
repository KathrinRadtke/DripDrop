using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackgrounds : MonoBehaviour
{
    [SerializeField] private Sprite[] skies;    
    [SerializeField] private Sprite[] suns;
    [SerializeField] private Sprite[] mountains;
    [SerializeField] private Sprite[] forests;

    [SerializeField] private SpriteRenderer sky;
    [SerializeField] private SpriteRenderer sun;
    [SerializeField] private SpriteRenderer mountain;
    [SerializeField] private SpriteRenderer forest;


    public void SetLevelBackground(int levelIndex)
    {
        sky.sprite = skies[levelIndex];
        sun.sprite = suns[levelIndex];
        mountain.sprite = mountains[levelIndex];
        forest.sprite = forests[levelIndex];
    }
}
