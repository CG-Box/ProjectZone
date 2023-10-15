using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    public float moveSpeed = 1f;
    public List<Transform> pointsList;
    int currentPointIndex = 0;
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

            if(currentPointIndex == pointsList.Count)
                currentPointIndex = 0;
        }
    }
}
