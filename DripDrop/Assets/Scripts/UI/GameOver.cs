using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject unlockedText;
    [SerializeField] private GameObject diedText;

    [SerializeField] private GameObject mainMenu;

    public void OnClick()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
        SoundSystem.Instance().PlaySound("blub");
    }

    public void Show(bool unlocked)
    {
        gameObject.SetActive(true);
        unlockedText.SetActive(unlocked);
        diedText.SetActive(!unlocked);
    }
    
}
