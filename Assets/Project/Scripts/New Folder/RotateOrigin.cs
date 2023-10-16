using UnityEngine;

public class RotateOrigin : MonoBehaviour
{
    [SerializeField]
    private Transform rotateCircle;

    Transform targetLock;

    float angle;

    Vector3 originalCircleLocalScale;

    void Start()
    {
        originalCircleLocalScale = rotateCircle.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetLock)
        {
            NewUtility.Utility.RotateObjectToTarget2D(rotateCircle, targetLock);
        }
        else
        {
            rotateCircle.rotation = Quaternion.identity ;    
        }
        
        AdaptCircleRotation();
    }

    void AdaptCircleRotation()
    {
        Vector3 direction = rotateCircle.transform.right;

        //flip gun at 90* 
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Vector3 localScale = originalCircleLocalScale;
        if(angle > 90 || angle < -90)
        {
            localScale.y = -Mathf.Abs(localScale.y);
        }
        else
        {
            localScale.y = Mathf.Abs(localScale.y);
        }

        rotateCircle.localScale = localScale;
    }

    public void LockTarget(Transform target)
    {
        targetLock = target;
    }

    public void UnlockTarget()
    {
        targetLock = null;
    }
}
