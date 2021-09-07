using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AnimationCurve sizeDistribution;
    [SerializeField] private float sizeVariation = 0.2f;
    [SerializeField] private GameObject collectablePrefab;

    private GameObject currentCollectable;
    
    public IEnumerator GenerateLevel(float count, float minY, float maxY)
    {
        for (int i = 0; i < count; i++)
        {
            currentCollectable = Instantiate(collectablePrefab, Vector3.zero, Quaternion.identity, transform);
            
            SetSizeAndPosition(minY, maxY);
            yield return null;  

            List<Collider2D> results = new List<Collider2D>();
            int safetyCounter = 0;
            
            while (currentCollectable.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), results) > 0)
            {
                if (safetyCounter > 500)
                {
                    Destroy(currentCollectable);
                }

                SetSizeAndPosition(minY, maxY);
                
                safetyCounter++;
                yield return null;
            }
            
        }
    }

    private void SetSizeAndPosition(float minY, float maxY)
    {
        Vector3 collectablePosition = Vector3.zero;
        collectablePosition.x = Random.Range(-2f, 2f);
        collectablePosition.y = Random.Range(minY, maxY);
        currentCollectable.transform.position = collectablePosition;
        
        float collectableSize = sizeDistribution.Evaluate(Mathf.InverseLerp(minY, maxY, collectablePosition.y));
        collectableSize = Random.Range(collectableSize + sizeVariation, collectableSize - sizeVariation);
        collectableSize = Mathf.Clamp(collectableSize, sizeDistribution.Evaluate(0), sizeDistribution.Evaluate(1));
        
        currentCollectable.GetComponent<Collectable>().SetScale(collectableSize);
    }
    
}
