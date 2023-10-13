using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEventParam : MonoBehaviour
{
    public void GetSenderEvent (object sender)
    {
        NewEventFunction typed = (NewEventFunction)sender;
        //typed.SayHello("Mark");

        var convertedObject = System.Convert.ChangeType(sender, sender.GetType());
        //Debug.LogWarning(convertedObject);

        //MonoBehaviour btn = (MonoBehaviour)sender;
    }

/*
    void MyMethod(object obj, System.Type t)
    {
        var convertedObject = System.Convert.ChangeType(obj, t);
    }*/
}
