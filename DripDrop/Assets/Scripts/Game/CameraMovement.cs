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

    public bool isMoving;
    
    public delegate void LevelComplete();
    public LevelComplete OnLevelComplete;
    
    public delegate void Reset();
    public Reset OnReset;
    
    void Update()
    {
        if (isMoving)
        {
            if (timer < movementTime)
            {
                currentPosition.y = Mathf.Lerp(startPosition, endPosition, GetMovementPercentage());
                transform.position = currentPosition;
                timer += Time.deltaTime;
            }
            else
            {
                OnLevelComplete?.Invoke();
                isMoving = false;
            }
        }
    }

    public void StartLevel()
    {
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }

    public void ResetPositions()
    {
        timer = 0;
        currentPosition.y = startPosition;
        transform.position = currentPosition;
        
        OnReset?.Invoke();
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
