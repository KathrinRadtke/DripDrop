using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int level = 1;

    public float scale;

    void Start()
    {
    }
    
    public void SetScale(float scale)
    {
        this.scale = scale;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
