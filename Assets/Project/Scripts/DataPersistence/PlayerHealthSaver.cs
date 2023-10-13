using UnityEngine;

[RequireComponent(typeof(HealthBehaviour))]
public class PlayerHealthSaver : MonoBehaviour, IDataPersistence
{
    HealthBehaviour healthBehaviour;
    private void Awake()
    {
        healthBehaviour = GetComponent<HealthBehaviour>();
    }

    public void LoadData(GameData data) 
    {

        healthBehaviour.SetHealt(data.globals.playerHealth);
    }

    public void SaveData(GameData data) 
    {
        data.globals.playerHealth = healthBehaviour.Health;
    }
}
