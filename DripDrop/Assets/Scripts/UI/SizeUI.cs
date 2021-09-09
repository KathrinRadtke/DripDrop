using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SizeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private AnimationCurve sizeCurve;

    public void SetSizeText(float scale)
    {
        float size = sizeCurve.Evaluate(scale);
        sizeText.text = size.ToString("0.0");
    }
}
