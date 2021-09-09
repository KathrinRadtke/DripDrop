using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AnimationCurve sizeDistribution;
    [SerializeField] private float sizeVariation = 0.2f;
    [SerializeField] private GameObject collectablePrefab;

    private GameObject currentCollectable;

    private List<GameObject> currentDrops = new List<GameObject>();
    
    public IEnumerator GenerateLevel(float count, float minY, float maxY)
    {
        currentDrops = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            currentCollectable = Instantiate(collectablePrefab, Vector3.zero, Quaternion.identity, transform);
            currentDrops.Add(currentCollectable);
            
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

        foreach (var drop in currentDrops)
        {
            drop.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void ResetLevel()
    {
        foreach (var drop in currentDrops)
        {
            Destroy(drop.gameObject);
        }
    }

    private void SetSizeAndPosition(float minY, float maxY)
    {
        Vector3 collectablePosition = Vector3.zero;
        collectablePosition.x = Random.Range(-2.5f, 2.5f);
        collectablePosition.y = Random.Range(minY, maxY);
        currentCollectable.transform.position = collectablePosition;
        
        float collectableSize = sizeDistribution.Evaluate(Mathf.InverseLerp(minY, maxY, collectablePosition.y));
        collectableSize = Random.Range(collectableSize + sizeVariation, collectableSize - sizeVariation);
        collectableSize = Mathf.Clamp(collectableSize, sizeDistribution.Evaluate(0), sizeDistribution.Evaluate(1));
        
        currentCollectable.GetComponent<Collectable>().SetScale(collectableSize);
    }
    
}
