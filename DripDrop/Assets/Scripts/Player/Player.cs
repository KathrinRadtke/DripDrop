using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float minScale = 0.4f;
    private float maxScale = 1f;
    private float scale = 0.4f;
    private Vector3 localScale = Vector3.one;
    [SerializeField] private float scaleTolerance = 0.05f;
    [SerializeField] private float growMultiplier = 0.1f;
    [SerializeField] private float shrinkMultiplier = 0.1f;
    [SerializeField] private Transform scaledTransform;

    [SerializeField] private SizeUI sizeUI;
    [SerializeField] private Level level;

    [SerializeField] private CameraMovement cameraMovement;


    void Start()
    {
        SetScale();        
    }

    public void ResetSize()
    {
        scale = minScale;
        SetScale();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cameraMovement.isMoving)
        {
            Collectable collectable = other.GetComponent<Collectable>();
            if (collectable != null)
            {
                if (collectable.scale <= scale + scaleTolerance)
                {
                    scale += collectable.scale * growMultiplier;
                    SoundSystem.Instance().PlaySound("blub", 0.7f, 1.3f);
                }
                else
                {
                    scale -= collectable.scale * shrinkMultiplier;
                    SoundSystem.Instance().PlaySound("slurp");

                    if (scale >= minScale)
                    {
                        Fade.DoFade(0.05f, 0.05f, 0.05f);
                    }
                }

                SetScale();
                Destroy(collectable.gameObject);
            }

            sizeUI.SetSizeText(scale);
        }
    }

    private void SetScale()
    {
        if (scale < minScale)
        {
            level.GameOver();
        }

        scale = Mathf.Clamp(scale, minScale, maxScale);
        localScale.x = scale;
        localScale.y = scale;
        scaledTransform.localScale = localScale;
    }
}
