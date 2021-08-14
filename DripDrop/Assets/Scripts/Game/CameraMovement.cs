using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float startPosition;
    
    private float endPosition;
    private float movementTime;

    private float timer = 0f;
    private Vector3 currentPosition = new Vector3(0, 0, -10f);
    

    void Update()
    {
        if (timer < movementTime)
        {
            currentPosition.y = Mathf.Lerp(startPosition, endPosition, GetMovementPercentage());
            transform.position = currentPosition;
            timer += Time.deltaTime;
        }
    }

    public float GetMovementPercentage()
    {
        return timer / movementTime;
    }

    public void SetLevelSettings(float endPosition, float movementTime)
    {
        this.endPosition = endPosition;
        this.movementTime = movementTime;
    }
}
