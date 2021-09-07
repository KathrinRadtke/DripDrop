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


    void Start()
    {
        SetScale();        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectable collectable = other.GetComponent<Collectable>();
        if (collectable != null)
        {
            if (collectable.scale <= scale + scaleTolerance)
            {
                scale += collectable.scale * growMultiplier;
                SetScale();
                Destroy(collectable.gameObject);
            }
            else
            {
                scale-= collectable.scale * shrinkMultiplier;
                SetScale();
            }
        }
    }

    private void SetScale()
    {
        scale = Mathf.Clamp(scale, minScale, maxScale);
        localScale.x = scale;
        localScale.y = scale;
        scaledTransform.localScale = localScale;
    }
}
