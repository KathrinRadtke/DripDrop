using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;

    private Vector3 currentPosition = new Vector3(0, 0, 10);

    private CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition.y = Mathf.Lerp(startPosition, endPosition, cameraMovement.GetMovementPercentage());
        transform.localPosition = currentPosition;
    }
}
