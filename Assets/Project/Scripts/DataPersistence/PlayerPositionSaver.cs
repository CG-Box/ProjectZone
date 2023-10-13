using UnityEngine;

public class PlayerPositionSaver : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data) 
    {
        this.transform.position = data.scene.playerPosition;
    }

    public void SaveData(GameData data) 
    {
        data.scene.playerPosition = this.transform.position;
    }
}
