using System.Collections.Generic;
using UnityEngine;

public class DeathLoot : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyController;
 
    public List<ItemData_SO> itemsToSpawn;

    void OnEnable()
    {
        StaticEvents.Combat.OnEnemyDeath += SpawnLoot;
    }
    void OnDisable()
    {
        StaticEvents.Combat.OnEnemyDeath -= SpawnLoot;
    }


    private void SpawnLoot(EnemyController enemyController)
    {
        if(this.enemyController == enemyController)
        {
            foreach (ItemData_SO item in itemsToSpawn)
            {
                StaticEvents.Spawning.OnSpawnItem?.Invoke(item.Data, transform.position);
            }
        }
    }
}
