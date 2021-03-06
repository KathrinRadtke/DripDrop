using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelSettings : ScriptableObject
{
    public int levelIndex;
    public int endPosition;
    public int movementTime;
    public int collectableCount;
}
