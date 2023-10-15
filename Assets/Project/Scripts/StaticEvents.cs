using System;
using UnityEngine;

public class StaticEvents
{ 
    
  public class PlayerHealth
  {
    //public static Action<float> OnHealthChanged;
    //public static Action<float> OnHealthDecreased;
    //public static Action<float> OnHealthIncreased;

    public static Action<float, GameObject> OnRestoreHealth;
  }
    
  public class Collecting
  {
    public static Action<ItemBase> OnItemCollect;
    public static Action<ItemBase, GameObject> OnItemRemove;
    public static Action<ItemBase, GameObject> OnItemUse;
    public static Action OnOutOfAmmo;
  }

  public class Combat
  {
    public static Action<GameObject> OnEnemyDeath;
    public static Action OnPlayerDeath;
  }

  public class Spawning
  {
    public static Action<Transform> OnShootBullet;
    public static Func<ItemBase, Vector3, Item> OnSpawnItem;
  }

  public class Controls
  {
    public static Action OnUsePressed;
    public static Action OnUseHold;
    public static Action OnUseReleased;
  }

    /*
  public class Ui
  {
    public static Action OnMenuOpen;

    public static Action OnMenuClose;

    public static Action<int> OnLevelLoad;

    public static EventHandler OnExiTPressed; //EventArgs.Empty
    public static EventHandler<ButtonEventArgs> OnButtonPressed;

    public class ButtonEventArgs: EventArgs
    {
        public readonly int buttonCode;
        public ButtonEventArgs(int code) => buttonCode = code;
    }
  }
  */
}