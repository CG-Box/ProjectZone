using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForLock : MonoBehaviour
{
 
    public float moveSpeed = 1f;
    public List<Transform> pointsList;

    private int currentPointIndex = 0;

    void Awake(){}
    void Start()
    {
        StartCoroutine(MoveToNextPoint());
    }

    private IEnumerator MoveToNextPoint()
    {
        while (currentPointIndex < pointsList.Count)
        {
            Transform targetPoint = pointsList[currentPointIndex];
            while (transform.position != targetPoint.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            currentPointIndex++;
            yield return null;
        }
    }

    void Update()
    {
        
    }

    void MoveByPoints()
    {

    }
}
