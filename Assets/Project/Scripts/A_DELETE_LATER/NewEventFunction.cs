using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEventFunction : MonoBehaviour
{
    [field: SerializeField] 
    private GE_Params NewFunctionEvent;

    void MakeEvent()
    {
        // Создаем экземпляр пули
        //GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);
        NewFunctionEvent.Raise(this);
    }

    bool holdButton = false;
    void OnFire()
    {
        //Released button
        if(holdButton)
        {
            holdButton = false;
        }
        //Button pressed
        else
        {
            holdButton = true;
            MakeEvent();
        }
    }

    public void SayHello(string name)
    {
        Debug.Log($"<b>Hi</b> <color=red>I'm</color> <size=14>{name}/size>");
    }

}
