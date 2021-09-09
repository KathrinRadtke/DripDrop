using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private static Image fadeImage;
    private static Fade instance;
    
    public delegate void FadedOut();
    public static FadedOut OnFadedOut;
    
    public delegate void FadeComplete();
    public static FadeComplete OnFadeComplete;

    void Start()
    {
        instance = this;
        fadeImage = GetComponentInChildren<Image>();
        fadeImage.color = Color.clear;
        fadeImage.enabled = false;
    }


    public static void DoFade(float fadeOutTime, float waitTime, float fadeInTime)
    {
        instance.StartCoroutine(DoTheFade(fadeOutTime, waitTime, fadeInTime));
    }

    private static IEnumerator DoTheFade(float fadeOutTime, float waitTime, float fadeInTime)
    {
        fadeImage.enabled = true;
        Color color = Color.white;
        color.a = 0;
        float timer = 0;
        while (timer < fadeOutTime)
        {
            color.a = Mathf.Lerp(0, 1, timer / fadeOutTime);
            fadeImage.color = color;
            timer += Time.deltaTime;
            yield return null;
        }

        OnFadedOut?.Invoke();
        yield return new WaitForSeconds(waitTime);
        timer = 0;
        while (timer < fadeInTime)
        {
            color.a = Mathf.Lerp(1, 0, timer / fadeInTime);
            fadeImage.color = color;
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = Color.clear;
        fadeImage.enabled = false;
        
        OnFadeComplete?.Invoke();
    }

}
