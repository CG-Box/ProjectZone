using UnityEngine;

//#if UNITY_EDITOR
//#endif

public static class EditorDebug
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Log<T>(T message)
    {
        Debug.Log(message);
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogWarning<T>(T message)
    {
        Debug.LogWarning(message);
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogError<T>(T message)
    {
        Debug.LogError(message);
    }
}