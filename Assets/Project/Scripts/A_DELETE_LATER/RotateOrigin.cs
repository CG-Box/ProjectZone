using UnityEngine;

public class RotateOrigin : MonoBehaviour
{
    [SerializeField]
    private Transform rotateCircle;

    [SerializeField]
    private Transform targetLock;

    // Update is called once per frame
    void Update()
    {
        if(targetLock)
            NewUtility.Utility.RotateObjectToTarget2D(rotateCircle, targetLock);
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
